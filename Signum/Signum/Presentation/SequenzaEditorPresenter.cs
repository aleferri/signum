using ModelManaging;
using Signum.Common;
using Signum.Model;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Presentation
{
    [NameTagAttribute("Sequenza", typeof(Sequenza))]
    class SequenzaEditorPresenter : IEditorPresenter
    {
        private SequenzaEditor _editor;
        private Sequenza _sequenza;
        private ModelToPersistenceWrapper<Sequenza> _wrapper;
        private ElementoEditorPresenter _elementEditorPresenter;
        private EditorFactory _editorFactory;
        private Elemento _currentElemento;
        private int _draggedElementIndex;

        public EventHandler OnSave => OnSaveRequest;
        public Control Editor => _editor;

        public SequenzaEditorPresenter(Modello modello)
        {
            _editor = new SequenzaEditor();
            _editorFactory = Documento.getInstance().EditorFactory;
            _editor.Dock = DockStyle.Fill;
            Sequenza s = new Sequenza();
            s.AggiungiElemento(Elemento.Default, 1);
            CaricaSequenza(new ModelToPersistenceWrapper<Sequenza>(s));

            _draggedElementIndex = -1;

            PopulateElementChoices();
            AttachHandlers();
        }

        private void PopulateElementChoices()
        {
            foreach(string name in _editorFactory.ElementEditorNames)
            {
                ToolStripMenuItem voice = new ToolStripMenuItem()
                {
                    Text = name,
                    Tag = _editorFactory.GetTagFromName(name)
                };
                _editor.AggiungiMenu.DropDownItems.Add(voice);
            }
        }
        private void AttachHandlers()
        {
            _editor.Lista.MouseDoubleClick += OnListDoubleClick;
            _editor.DurataNumeric.ValueChanged += OnDurationChange;
            _editor.Lista.MouseDown += OnListMouseDown;
            _editor.Lista.MouseMove += OnListMouseMove;
            _editor.Lista.MouseUp += OnListMouseUp;
            _editor.Lista.SelectedIndexChanged += OnListSelectedChange;
            _editor.EliminaOption.Click += OnEliminaClick;
            _editor.MoveUpOption.Click += OnUpClick;
            _editor.MoveDownOption.Click += OnDownClick;
            foreach(ToolStripMenuItem item in _editor.AggiungiMenu.DropDownItems)
            {
                item.Click += OnNuovoClick;
            }
        }
        private void FillList()
        {
            _editor.Lista.DataSource = null;
            _editor.Lista.DataSource = _sequenza.GetList();
            _editor.Lista.DisplayMember = "Nome";
        }
        private void SetViewFromModel(Elemento e)
        {
            _currentElemento = e;
            ElementoEditorPresenter presenter = _editorFactory.GetEditorHandler(
                e.GetType(), Documento.getInstance().ModelloRiferimento) as ElementoEditorPresenter;
            presenter.CaricaElemento(new ModelToPersistenceWrapper<Elemento>(e));
            _editor.DurataNumeric.Value = _sequenza.GetDurataOf(e);
            _editor.NomeField.Text = e.Nome;
            _editor.SetEditor(presenter.Editor);
            _elementEditorPresenter = presenter;
        }
        private void OpenEditorForIndex(int index)
        {
            Elemento e = _sequenza[index];
            SetViewFromModel(e);
        }
        private void Move(bool up, int index)
        {
            Elemento e = _sequenza[index];
            uint durata = _sequenza.GetDurataOf(e);
            int offset = up ? -1 : 1;
            _sequenza.EliminaElemento(index);
            _sequenza.InserisciElemento(e, durata, index + offset);
            FillList();
        }

        public void CaricaSequenza(ModelToPersistenceWrapper<Sequenza> sequenza)
        {
            _sequenza = sequenza.ModelElement;
            _wrapper = sequenza;
            FillList();
            OpenEditorForIndex(0);
        }
        public void CaricaModello(ModelToPersistenceWrapper oggettoModello)
        {
            ModelToPersistenceWrapper<Sequenza> tmp = oggettoModello as ModelToPersistenceWrapper<Sequenza>;
            CaricaSequenza(tmp ?? throw new ArgumentException("Oggetto passato non compatibile all'editor delle sequenze"));
        }

        #region EventHandlers
        private void OnListDoubleClick(object sender, MouseEventArgs args)
        {
            int index = _editor.Lista.IndexFromPoint(args.Location);
            if (index == ListBox.NoMatches)
            {
                return;
            }
            OpenEditorForIndex(index);
        }
        private void OnListMouseDown(object sender, MouseEventArgs args)
        {
            if (args.Button == MouseButtons.Left)
            {
                _draggedElementIndex = _editor.Lista.SelectedIndex;
            }
        }
        private void OnListMouseMove(object sender, MouseEventArgs args)
        {
            if (0 > _draggedElementIndex) return;
            int hoverIndex = _editor.Lista.IndexFromPoint(new Point(args.X, args.Y));
            if(hoverIndex != _draggedElementIndex && hoverIndex >= 0)
            {
                Move(hoverIndex < _draggedElementIndex, _draggedElementIndex);
                _draggedElementIndex = hoverIndex;
            }
        }
        private void OnListMouseUp(object sender, MouseEventArgs args)
        {
            _draggedElementIndex = -1;
            if (args.Button == MouseButtons.Right)
            {
                Point point = new Point(args.X, args.Y);
                _editor.Lista.SelectedIndex = _editor.Lista.IndexFromPoint(point);
                _editor.Lista.ContextMenuStrip.Show(_editor.Lista, point);
            }
        }
        private void OnNuovoClick(object sender, EventArgs args)
        {
            string nome = InputPrompt.ShowInputDialog("Nome del nuovo elemento da aggiungere", "Nuovo elemento", "OK", "Annulla");
            if (null == nome || nome == "") return;
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Type type = (Type)item.Tag;
            Elemento e = (Elemento)type.GetProperty("Empty", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                .GetValue(null);
            e.Nome = nome;
            _sequenza.AggiungiElemento(e, 1);
            FillList();
            SetViewFromModel(e);

        }
        private void OnDurationChange(object sender, EventArgs args)
        {
            _sequenza.SetDurataOf(_currentElemento, (uint) _editor.DurataNumeric.Value);
        }
        private void OnListSelectedChange(object sender, EventArgs args)
        {
            int index = _editor.Lista.SelectedIndex;
            _editor.MoveUpOption.Enabled = index != 0;
            _editor.MoveDownOption.Enabled = index != _sequenza.Count - 1;
        }
        private void OnSaveRequest(object sender, EventArgs args)
        {
            if (null == _sequenza.Nome || "" == _sequenza.Nome)
            {
                string nome = InputPrompt.ShowInputDialog("Inserisci il nome per il nuovo elemento", "Nuovo Elemento", "Ok", "Annulla");
                if (null == nome) return;
                _sequenza.Nome = nome;
            }

            Documento.getInstance().Libreria.AggiungiSequenza(_wrapper);
        }
        private void OnEliminaClick(object sender, EventArgs args)
        {
            int index = _editor.Lista.SelectedIndex;
            Elemento e = _sequenza[index];
            if(e == _currentElemento)
            {
                if (_sequenza.Count == 1) return;
                int offset = index == 0 ? 1 : -1;
                SetViewFromModel(_sequenza[index + offset]);
            }
            _sequenza.EliminaElemento(index);
            FillList();
        }
        private void OnUpClick(object sender, EventArgs args)
        {
            Move(true, _editor.Lista.SelectedIndex);
        }
        private void OnDownClick(object sender, EventArgs args)
        {
            Move(false, _editor.Lista.SelectedIndex);
        }
        #endregion
    }
}
