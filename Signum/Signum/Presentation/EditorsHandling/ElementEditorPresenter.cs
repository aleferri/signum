using Signum.Model;
using Signum.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Presentation.EditorsHandling
{
    abstract class ElementEditorPresenter : IEditorPresenter
    {
        private ElementEditor _editor;

        public abstract EventHandler OnSave { get; }
        protected IInformazione Informazione => _editor.DateHourCheckBox.Checked ? (IInformazione)new InformazioneDataOra() : new InformazioneTestuale(_editor.InfoBox.Text);
        public Control Editor => _editor;

        protected ElementEditorPresenter()
        {
            _editor = new ElementEditor()
            {
                Dock = DockStyle.Fill
            };
            _editor.DateHourCheckBox.CheckedChanged += OnCheckedChanged;
        }

        protected void SetEditor(Control editor)
        {
            _editor.SpecificEditor = editor;
        }

        public abstract void CaricaElemento(Elemento element);

        private void OnCheckedChanged(object sender, EventArgs args)
        {
            _editor.InfoBox.Enabled = !_editor.DateHourCheckBox.Checked;
        }

        protected void ImportaInformazione(IInformazione informazione)
        {
            if(!(_editor.DateHourCheckBox.Checked = informazione is InformazioneDataOra))
            {
                _editor.InfoBox.Text = informazione.Accept(new ValutatoreInformazione());
            }
        }
    }
}
