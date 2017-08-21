using ModelManaging;
using Signum.Model;
using Signum.Presentation.EditorsHandling;
using System;

namespace Signum.Presentation
{
    [NameTagAttribute("Immagine Fissa", typeof(ImmagineFissa))]
    class ImmagineFissaEditorPresenter : ElementoEditorPresenter
    {
        private FrameEditorPresenter _presenter;
        private ImmagineFissa _img;

        public ImmagineFissaEditorPresenter(Modello modello)
        {
            CaricaElemento(new PersisterMapper<Elemento>(new ImmagineFissa(new Frame(modello.Size))));
        }

        /// <summary>
        /// Dato il persisterMapper di un elemento, se esso è un'immagine fissa verrà caricato nell'editor.
        /// </summary>
        /// <param name="element"></param>
        public override void CaricaElemento(PersisterMapper<Elemento> element)
        {
            ImmagineFissa immagine = element.Element as ImmagineFissa;
            _img = immagine ?? throw new ArgumentException("Elemento non compatibile con l'editor delle immagini fisse");
            Mapper = element;
            _presenter = new FrameEditorPresenter(immagine.Frame, Documento.getInstance().ModelloRiferimento);
            SetEditor(_presenter.Editor);
        }
    }
}
