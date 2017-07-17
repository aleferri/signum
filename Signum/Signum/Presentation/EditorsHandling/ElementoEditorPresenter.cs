using Signum.Common;
using Signum.Model;
using Signum.View;
using System;
using System.Windows.Forms;

namespace Signum.Presentation.EditorsHandling
{
    abstract class ElementoEditorPresenter : IEditorPresenter
    {
        public abstract event EventHandler EditorChange;

        private ElementEditor _editor;
        private MementoWrapper<Elemento> _wrapper;

        public EventHandler OnSave => Save;
        public EventHandler OnBack => Back;
        public EventHandler OnForward => Forward;
        protected MementoWrapper<Elemento> Wrapper
        {
            get => _wrapper;
            set
            {
                _wrapper = value;
                if (null == value) throw new ArgumentNullException("Elemento nullo per l'editor presenter");
                ImportaInformazione(Wrapper.Memento.InformazioneAssociata);
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

        public abstract void CaricaElemento(MementoWrapper<Elemento> element);

        public void CaricaModello(MementoWrapper oggettoModello)
        {

            MementoWrapper<Elemento> tmp = new MementoWrapper <Elemento>((Elemento)oggettoModello.ObjectModelElement, oggettoModello.ID);
            CaricaElemento(tmp);
        }
        public bool CanGoBack()
        {
            return Wrapper.CanGoBack();
        }
        public bool CanGoForward()
        {
            return Wrapper.CanGoForward();
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
            if(null == Wrapper.Memento.Nome || "" == Wrapper.Memento.Nome)
            {
                string nome = InputPrompt.ShowInputDialog("Inserisci il nome per il nuovo elemento", "Nuovo Elemento", "Ok", "Annulla");
                if (null == nome) return;
                Wrapper.Memento.Nome = nome;
            }
            Documento.getInstance().Libreria.AggiungiElemento(Wrapper);
        }
        private void Back(object sender, EventArgs args)
        {
            Wrapper.Back();
            CaricaElemento(Wrapper);
        }
        private void Forward(object sender, EventArgs args)
        {
            Wrapper.Forward();
            CaricaElemento(Wrapper);
        }
        private void OnCheckedChanged(object sender, EventArgs args)
        {
            bool check = _editor.DateHourCheckBox.Checked;
            _editor.InfoBox.Enabled = !check;
            Wrapper.Memento.InformazioneAssociata = check ? (IInformazione)new InformazioneDataOra() : new InformazioneTestuale(_editor.InfoBox.Text);
        }
        public void OnInfoBoxChanged(object sender, EventArgs args)
        {
            Wrapper.Memento.InformazioneAssociata = new InformazioneTestuale(_editor.InfoBox.Text);
        }
        #endregion
    }
}
