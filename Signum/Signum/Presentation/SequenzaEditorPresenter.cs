using ModelManaging;
using Signum.Common;
using Signum.Model;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private ElementEditorPresenter _elementEditorPresenter;
        private EditorFactory _editorFactory;

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
            _editor.Lista.MouseDoubleClick += OnListClick;
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
            ElementEditorPresenter presenter = _editorFactory.GetEditorHandler(
                e.GetType(), Documento.getInstance().ModelloRiferimento) as ElementEditorPresenter;
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

        public void CaricaSequenza(Sequenza sequenza)
        {
            _sequenza = sequenza;
            FillList();
            _editor.SequenzaNomeField.Text = _sequenza.Nome;
        }

        #region EventHandlers
        private void OnListClick(object sender, MouseEventArgs args)
        {
            int index = _editor.Lista.IndexFromPoint(args.Location);
            if (index == ListBox.NoMatches)
            {
                return;
            }
            OpenEditorForIndex(index);
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
        private void OnSaveRequest(object sender, EventArgs args)
        {

        }
        #endregion
    }
}
