using Signum.Model;
using System;
using System.Windows.Forms;

namespace Signum.Presentation.EditorsHandling
{
    public interface IEditorPresenter
    {
        EventHandler OnSave { get; }
        Control Editor { get; }

        void CaricaModello(ModelToPersistenceWrapper oggettoModello);
    }
}
