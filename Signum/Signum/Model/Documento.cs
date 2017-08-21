using ModelManaging;
using Signum.Presentation.EditorsHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class ModelEventArgs : EventArgs
    {
        public Modello NuovoModello { get; set; }

        public ModelEventArgs(Modello modello)
        {
            NuovoModello = modello;
        }
    }

    public delegate void ModelChangeHandler(object sender, ModelEventArgs args);
    public class Documento
    {

        private static readonly string LIBRARY_PATH = @"libreria\";

        #region Static
        private readonly static Documento _instance = null;

        static Documento()
        {
            _instance = new Documento();
        }
        public static Documento getInstance()
        {
            return _instance;
        }

        #endregion

        #region Instance

        public event ModelChangeHandler ModelChanged;
        public event EventHandler LibreriaChanged;

        private Modello _modelloRiferimento;
        private ILibreria _libreria;

        public Modello ModelloRiferimento
        {
            get => _modelloRiferimento;
            set
            {
                _modelloRiferimento = value;
                _libreria = new Libreria(LIBRARY_PATH);
                _libreria.LibreriaChange += OnLibreriaChange;
                ModelChanged?.Invoke(this, new ModelEventArgs(value));
                LibreriaChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public EditorFactory EditorFactory { get; }
        public ILibreria Libreria => _libreria;

        private Documento()
        {
            EditorFactory = new EditorFactory();
        }

        private void OnLibreriaChange(object sender, EventArgs args)
        {
            LibreriaChanged(sender, args);
        }
        #endregion
    }
}
