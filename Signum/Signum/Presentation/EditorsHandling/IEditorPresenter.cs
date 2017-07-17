using Signum.Model;
using System;
using System.Windows.Forms;

namespace Signum.Presentation.EditorsHandling
{
    public interface IEditorPresenter
    {
        event EventHandler EditorChange;

        EventHandler OnSave { get; }
        EventHandler OnBack { get; }
        EventHandler OnForward { get; }
        Control Editor { get; }

        void CaricaModello(MementoWrapper oggettoModello);
        bool CanGoBack();
        bool CanGoForward();
    }
}
