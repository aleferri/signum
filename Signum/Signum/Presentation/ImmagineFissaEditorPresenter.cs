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
    class ImmagineFissaEditorPresenter : ElementoEditorPresenter
    {
        private FrameEditorPresenter _presenter;
        private ImmagineFissa _img;

        public ImmagineFissaEditorPresenter(Modello modello)
        {
            _presenter = new FrameEditorPresenter(modello);
            CaricaElemento(new ModelToPersistenceWrapper<Elemento>(new ImmagineFissa(_presenter.CurrentResultFrame)));
        }

        public override void CaricaElemento(ModelToPersistenceWrapper<Elemento> element)
        {
            ImmagineFissa immagine = element.ModelElement as ImmagineFissa;
            _img = immagine ?? throw new ArgumentException("Elemento non compatibile con l'editor delle immagini fisse");
            AsElemento = _img;
            Wrapper = element;
            _presenter = new FrameEditorPresenter(immagine.Frame, Documento.getInstance().ModelloRiferimento);
            SetEditor(_presenter.Editor);
        }
    }
}
