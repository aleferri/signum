using Signum.Model;
using System;
using System.Windows.Forms;

namespace Signum.Presentation.EditorsHandling
{
    public interface IEditorPresenter
    {
        Control Editor { get; }

        /// <summary>
        /// Carica nell'editor un oggetto del modello contenuto nell'apposito wrapper
        /// </summary>
        /// <param name="oggettoModello"></param>
        void CaricaModello(PersisterMapper oggettoModello);

        /// <summary>
        /// EventHandler di salvataggio da parte dell'utente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnSave(object sender, EventArgs args);
    }
}
