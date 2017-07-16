using Signum.Common;
using Signum.Model;
using Signum.View;
using System;
using System.Windows.Forms;

namespace Signum.Presentation.EditorsHandling
{
    abstract class ElementoEditorPresenter : IEditorPresenter
    {
        private ElementEditor _editor;
        private Elemento _elemento;
        private ModelToPersistenceWrapper<Elemento> _wrapper;

        public EventHandler OnSave => Save;
        protected ModelToPersistenceWrapper<Elemento> Wrapper
        {
            get => _wrapper;
            set
            {
                _wrapper = value;
                if (null == value) throw new ArgumentNullException("Elemento nullo per l'editor presenter");
                _elemento = _wrapper.ModelElement;
                ImportaInformazione(_elemento.InformazioneAssociata);
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
            _editor.InfoBox.TextChanged += OnInfoBoxChanged;
        }

        protected void SetEditor(Control editor)
        {
            _editor.SpecificEditor = editor;
        }

        public abstract void CaricaElemento(ModelToPersistenceWrapper<Elemento> element);

        public void CaricaModello(ModelToPersistenceWrapper oggettoModello)
        {

            ModelToPersistenceWrapper<Elemento> tmp = new ModelToPersistenceWrapper <Elemento>((Elemento)oggettoModello.ObjectModelElement, oggettoModello.ID);
            CaricaElemento(tmp);
        }

        private void ImportaInformazione(IInformazione informazione)
        {
            bool isDataOra = informazione is InformazioneDataOra;
            if (!isDataOra)
            {
                _editor.InfoBox.Text = informazione.Accept(new ValutatoreInformazione());
            }
                _editor.DateHourCheckBox.Checked = isDataOra;
        }

        #region EventHandlers
        private void Save(object sender, EventArgs args)
        {
            if(null == _elemento.Nome || "" == _elemento.Nome)
            {
                string nome = InputPrompt.ShowInputDialog("Inserisci il nome per il nuovo elemento", "Nuovo Elemento", "Ok", "Annulla");
                if (null == nome) return;
                _elemento.Nome = nome;
            }
            Documento.getInstance().Libreria.AggiungiElemento(Wrapper);
        }
        private void OnCheckedChanged(object sender, EventArgs args)
        {
            if (null == _elemento) return;
            bool check = _editor.DateHourCheckBox.Checked;
            _editor.InfoBox.Enabled = !check;
            _elemento.InformazioneAssociata = check ? (IInformazione)new InformazioneDataOra() : new InformazioneTestuale(_editor.InfoBox.Text);
        }
        public void OnInfoBoxChanged(object sender, EventArgs args)
        {
            _elemento.InformazioneAssociata = new InformazioneTestuale(_editor.InfoBox.Text);
        }
        #endregion
    }
}
