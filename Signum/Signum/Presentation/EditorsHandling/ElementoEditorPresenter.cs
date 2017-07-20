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
        private PersisterMapper<Elemento> _wrapper;

        protected PersisterMapper<Elemento> Mapper
        {
            get => _wrapper;
            set
            {
                _wrapper = value;
                if (null == value) throw new ArgumentNullException("Elemento nullo per l'editor presenter");
                ImportaInformazione(Mapper.Element.InformazioneAssociata);
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

        private void ImportaInformazione(IInformazione informazione)
        {
            bool isDataOra = informazione is InformazioneDataOra;
            if (!isDataOra)
            {
                _editor.InfoBox.Text = informazione.Accept(new ValutatoreInformazione());
            }
            _editor.DateHourCheckBox.Checked = isDataOra;
        }

        protected void SetEditor(Control editor)
        {
            _editor.SpecificEditor = editor;
        }

        public abstract void CaricaElemento(PersisterMapper<Elemento> element);
        public void CaricaModello(PersisterMapper oggettoModello)
        {

            PersisterMapper<Elemento> tmp = new PersisterMapper <Elemento>((Elemento)oggettoModello.Element, oggettoModello.ID);
            CaricaElemento(tmp);
        }

        #region EventHandlers
        private void OnCheckedChanged(object sender, EventArgs args)
        {
            bool check = _editor.DateHourCheckBox.Checked;
            _editor.InfoBox.Enabled = !check;
            Mapper.Element.InformazioneAssociata = check ? (IInformazione)new InformazioneDataOra() : new InformazioneTestuale(_editor.InfoBox.Text);
        }

        public void OnInfoBoxChanged(object sender, EventArgs args)
        {
            Mapper.Element.InformazioneAssociata = new InformazioneTestuale(_editor.InfoBox.Text);
        }
        public void OnSave(object sender, EventArgs args)
        {
            if (null == Mapper.Element.Nome || "" == Mapper.Element.Nome)
            {
                string nome = InputPrompt.ShowInputDialog("Inserisci il nome per il nuovo elemento", "Nuovo Elemento", "Ok", "Annulla");
                if (null == nome) return;
                Mapper.Element.Nome = nome;
            }
            Documento.getInstance().Libreria.AggiungiElemento(Mapper);
        }
        #endregion
    }
}
