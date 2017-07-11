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
    abstract class ElementoEditorPresenter : IEditorPresenter
    {
        private ElementEditor _editor;
        private Elemento _elemento;

        public abstract EventHandler OnSave { get; }
        protected Elemento AsElemento
        {
            get => _elemento;
            set
            {
                if (null == value) throw new ArgumentNullException("Elemento nullo per l'editor presenter");
                ImportaInformazione(value.InformazioneAssociata);
                _elemento = value;
            }
        }
        public Control Editor => _editor;

        protected ElementoEditorPresenter()
        {
            _editor = new ElementEditor()
            {
                Dock = DockStyle.Fill
            };
            _editor.DateHourCheckBox.CheckedChanged += OnCheckedChanged;
            _editor.InfoBox.LostFocus += OnInfoBoxUnfocused;
        }

        protected void SetEditor(Control editor)
        {
            _editor.SpecificEditor = editor;
        }

        public abstract void CaricaElemento(Elemento element);

        private void ImportaInformazione(IInformazione informazione)
        {
            if(!(_editor.DateHourCheckBox.Checked = informazione is InformazioneDataOra))
            {
                _editor.InfoBox.Text = informazione.Accept(new ValutatoreInformazione());
            }
            _editor.InfoBox.Enabled = !_editor.DateHourCheckBox.Checked;
        }

        #region EventHandlers
        private void OnCheckedChanged(object sender, EventArgs args)
        {
            if (null == _elemento) return;
            bool check = _editor.DateHourCheckBox.Checked;
            _editor.InfoBox.Enabled = !check;
            _elemento.InformazioneAssociata = check ? (IInformazione)new InformazioneDataOra() : new InformazioneTestuale(_editor.InfoBox.Text);
        }
        public void OnInfoBoxUnfocused(object sender, EventArgs args)
        {
            if (_editor.DateHourCheckBox.Checked)
            {
                throw new Exception("Il testo dell'informazione è cambiato, ma non è uninformazione testuale");
            }

            _elemento.InformazioneAssociata = new InformazioneTestuale(_editor.InfoBox.Text);
        }
        #endregion
    }
}
