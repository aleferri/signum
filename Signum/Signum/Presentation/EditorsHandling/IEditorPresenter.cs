using Signum.Model;
using System;
using System.Windows.Forms;

namespace Signum.Presentation.EditorsHandling
{
    public interface IEditorPresenter
    {
        Control Editor { get; }

        void CaricaModello(PersisterMapper oggettoModello);

        void OnSave(object sender, EventArgs args);
    }
}
