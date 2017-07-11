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
        private ElementoEditorPresenter _elementEditorPresenter;
        private EditorFactory _editorFactory;
        private Elemento _currentElemento;

        public EventHandler OnSave => OnSaveRequest;
        public Control Editor => _editor;

        public SequenzaEditorPresenter(Modello modello)
        {
            _editor = new SequenzaEditor();
            _editorFactory = Documento.getInstance().EditorFactory;
            _editor.Dock = DockStyle.Fill;
            _sequenza = new Sequenza();
            if (0 == _sequenza.Count) _sequenza.AggiungiElemento(Elemento.Default, 1);
            FillList();
            PopulateElementChoices();
            AttachHandlers();
            OpenEditorForIndex(0);
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
            presenter.CaricaElemento(e);
            _editor.DurataNumeric.Value = _sequenza.GetDurataOf(e);
            _editor.NomeField.Text = e.Nome;
            _editor.SetEditor(presenter.Editor);
            _elementEditorPresenter = presenter;
        }
        private void OpenEditorForIndex(int index)
        {
            Elemento e = (Elemento)_editor.Lista.Items[index];
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

        public void CaricaSequenza(Sequenza sequenza)
        {
            _sequenza = sequenza;
            FillList();
            _editor.SequenzaNomeField.Text = _sequenza.Nome;
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
        private void OnListMouseUp(object sender, MouseEventArgs args)
        {
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
