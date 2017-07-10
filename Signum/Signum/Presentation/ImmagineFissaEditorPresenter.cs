using ModelManaging;
using Signum.Common;
using Signum.Model;
using Signum.Persistence;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Signum.Presentation
{
    [NameTagAttribute("Immagine Fissa", typeof(ImmagineFissa))]
    class ImmagineFissaEditorPresenter : ElementEditorPresenter
    {
        private FrameEditorPresenter _presenter;
        private ImmagineFissa _img;
        public override EventHandler OnSave => OnSaveHandler;

        public ImmagineFissaEditorPresenter(Modello modello)
        {
            _presenter = new FrameEditorPresenter(modello);
            CaricaElemento(new ImmagineFissa(_presenter.CurrentResultFrame));
        }

        public override void CaricaElemento(Elemento element)
        {
            ImmagineFissa immagine = element as ImmagineFissa;
            _img = immagine ?? throw new ArgumentException("Elemento non compatibile con l'editor delle immagini fisse");
            _presenter = new FrameEditorPresenter(immagine.Frame, Documento.getInstance().ModelloRiferimento);
            SetEditor(_presenter.Editor);
            ImportaInformazione(immagine.InformazioneAssociata);
        }

        private void OnSaveHandler(object sender, EventArgs args)
        {
            _img = _img ?? new ImmagineFissa(_presenter.CurrentResultFrame, Informazione);
            if(null == _img.Nome)
            {
                string nome = InputPrompt.ShowInputDialog("Scegli il nome dell'elemento:", "Immagine Fissa", "OK", "Annulla");
                if (null == nome) return;
                _img.Nome = nome;
            }
            using(BinaryWriter bw = new BinaryWriter(new FileStream(Documento.LIBRARY_PATH + _img.Nome + ".elem", FileMode.Create), Encoding.UTF8))
            {
                PersisterFactory.GetPersister(PersisterFactory.IMMAGINE_FISSA).Save(_img, bw);
            }
        }
    }
}
