using ModelManaging;
using Signum.Model;
using Signum.Presentation.EditorsHandling;
using System;

namespace Signum.Presentation
{
    [NameTagAttribute("Immagine Fissa", typeof(ImmagineFissa))]
    class ImmagineFissaEditorPresenter : ElementoEditorPresenter
    {
        public override event EventHandler EditorChange;

        private FrameEditorPresenter _presenter;
        private ImmagineFissa _img;

        public ImmagineFissaEditorPresenter(Modello modello)
        {
            CaricaElemento(new MementoWrapper<Elemento>(new ImmagineFissa(new Frame(modello.Size))));
        }

        public override void CaricaElemento(MementoWrapper<Elemento> element)
        {
            ImmagineFissa immagine = element.Memento as ImmagineFissa;
            _img = immagine ?? throw new ArgumentException("Elemento non compatibile con l'editor delle immagini fisse");
            Wrapper = element;
            _presenter = new FrameEditorPresenter(immagine.Frame, Documento.getInstance().ModelloRiferimento);
            _presenter.FrameChange += OnFrameChange;
            SetEditor(_presenter.Editor);
            EditorChange?.Invoke(this, EventArgs.Empty);
        }

        private void OnFrameChange(object sender, EventArgs args)
        {
            Wrapper.AddStep(_img);
            CaricaElemento(Wrapper);
        }
    }
}
