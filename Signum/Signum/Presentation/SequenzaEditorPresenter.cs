using ModelManaging;
using Signum.Common;
using Signum.Model;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Signum.Presentation
{
    [NameTagAttribute("Sequenza", typeof(Sequenza))]
    class SequenzaEditorPresenter : IEditorPresenter
    {
        private SequenzaEditor _editor;
        private Sequenza _sequenza;
        private PersisterMapper<Sequenza> _wrapper;
        private ElementoEditorPresenter _elementEditorPresenter;
        private EditorFactory _editorFactory;
        private PersisterMapper<Elemento> _currentElemento;
        private int _draggedElementIndex;

        public Control Editor => _editor;

        public SequenzaEditorPresenter(Modello modello)
        {
            _editor = new SequenzaEditor();
            _editorFactory = Documento.getInstance().EditorFactory;
            _editor.Dock = DockStyle.Fill;
            CaricaSequenza(new PersisterMapper<Sequenza>(Sequenza.Default));

            _draggedElementIndex = -1;

            PopulateElementChoices();
            OnLibreriaChange(this, EventArgs.Empty);
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
                _editor.AggiungiOption.DropDownItems.Add(voice);
            }
        }
        private void AttachHandlers()
        {
            Documento.getInstance().LibreriaChanged += OnLibreriaChange;
            _editor.Lista.MouseDoubleClick += OnListDoubleClick;
            _editor.DurataNumeric.ValueChanged += OnDurationChange;
            _editor.Lista.MouseDown += OnListMouseDown;
            _editor.Lista.MouseMove += OnListMouseMove;
            _editor.Lista.MouseUp += OnListMouseUp;
            _editor.Lista.SelectedIndexChanged += OnListSelectedChange;
            _editor.EliminaOption.Click += OnEliminaClick;
            _editor.MoveUpOption.Click += OnUpClick;
            _editor.MoveDownOption.Click += OnDownClick;
            _editor.RenameOption.Click += OnRinominaClick;
            foreach(ToolStripMenuItem item in _editor.AggiungiOption.DropDownItems)
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
        private void SetViewFromModel(Elemento e, int index)
        {
            _currentElemento = new PersisterMapper<Elemento>(e, index);
            ElementoEditorPresenter presenter = _editorFactory.GetEditorHandler(
                e.GetType(), Documento.getInstance().ModelloRiferimento) as ElementoEditorPresenter;
            presenter.CaricaElemento(_currentElemento);
            _editor.DurataNumeric.Value = _sequenza.GetDurataOf(e);
            _editor.NomeField.Text = e.Nome;
            _editor.SetEditor(presenter.Editor);
            _elementEditorPresenter = presenter;
        }
        private void OpenEditorForIndex(int index)
        {
            Elemento e = _sequenza[index];
            SetViewFromModel(e, index);
        }
        private void Move(bool up, int index)
        {
            Elemento e = _sequenza[index];
            uint durata = _sequenza.GetDurataOf(index);
            int offset = up ? -1 : 1;
            _sequenza.EliminaElemento(index);
            _sequenza.InserisciElemento(e, durata, index + offset);
            FillList();
        }
        private void AggiuntaElemento(Elemento e)
        {
            _sequenza.AggiungiElemento(e, 1);
            FillList();
            SetViewFromModel(e, _sequenza.Count - 1);
        }

        public void CaricaSequenza(PersisterMapper<Sequenza> sequenza)
        {
            _sequenza = sequenza.Element;
            _wrapper = sequenza;
            FillList();
            OpenEditorForIndex(0);
        }
        public void CaricaModello(PersisterMapper oggettoModello)
        {
            PersisterMapper<Sequenza> tmp = oggettoModello as PersisterMapper<Sequenza>;
            CaricaSequenza(tmp ?? throw new ArgumentException("Oggetto passato non compatibile all'editor delle sequenze"));
        }

        #region EventHandlers
        private void OnListDoubleClick(object sender, MouseEventArgs args)
        {
            int index = _editor.Lista.IndexFromPoint(args.Location);
            if (index != ListBox.NoMatches)
            {
                OpenEditorForIndex(index);
            }         
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
            AggiuntaElemento(e);
        }
        private void OnDurationChange(object sender, EventArgs args)
        {
            _sequenza.SetDurataOf(_sequenza[_currentElemento.ID], (uint) _editor.DurataNumeric.Value);
        }
        private void OnListSelectedChange(object sender, EventArgs args)
        {
            int index = _editor.Lista.SelectedIndex;
            _editor.MoveUpOption.Enabled = index != 0;
            _editor.MoveDownOption.Enabled = index != _sequenza.Count - 1;
        }
        private void OnEliminaClick(object sender, EventArgs args)
        {
            int index = _editor.Lista.SelectedIndex;
            Elemento e = _sequenza[index];
            if(index == _currentElemento.ID)
            {
                if (_sequenza.Count == 1) return;
                int offset = index == 0 ? 1 : -1;
                SetViewFromModel(_sequenza[index + offset], index + offset);
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
        private void OnRinominaClick(object sender, EventArgs args)
        {
            int index = _editor.Lista.SelectedIndex;
            Elemento e = _sequenza[index];
            string newName = InputPrompt.ShowInputDialog("Rinomina l'elemento selezionato", "Rinomina", "OK", "Annulla", e.Nome);
            if (null == newName) return;
            e.Nome = newName;
            if (index == _currentElemento.ID)
            {
                _editor.NomeField.Text = newName;
            }
            FillList();
        }
        private void OnLibreriaChange(object sender, EventArgs args)
        {
            ILibreria libreria = Documento.getInstance().Libreria;
            _editor.DaLibreriaOption.DropDownItems.Clear();
            foreach (PersisterMapper<ImmagineFissa> el in libreria.ImmaginiFisse)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = el.Element.Nome;
                item.Tag = el.Element;
                _editor.DaLibreriaOption.DropDownItems.Add(item);
                item.Click += OnLibreriaItemClick;
            }

            _editor.DaLibreriaOption.DropDownItems.Add(new ToolStripSeparator());

            foreach (PersisterMapper<Animazione> el in libreria.Animazioni)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = el.Element.Nome;
                item.Tag = el.Element;
                _editor.DaLibreriaOption.DropDownItems.Add(item);
                item.Click += OnLibreriaItemClick;
            }
        }
        private void OnLibreriaItemClick(object sender, EventArgs args)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Elemento e = (Elemento)item.Tag;
            AggiuntaElemento(e);
        }

        public void OnSave(object sender, EventArgs args)
        {
            if (null == _sequenza.Nome || "" == _sequenza.Nome)
            {
                string nome = InputPrompt.ShowInputDialog("Inserisci il nome per il nuovo elemento", "Nuovo Elemento", "Salva", "Annulla");
                if (null == nome) return;
                _sequenza.Nome = nome;
            }
            Documento.getInstance().Libreria.AggiungiSequenza(_wrapper);
        }
        #endregion
    }
}
