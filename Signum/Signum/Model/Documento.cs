using ModelManaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class Documento
    {
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

        private Modello _modelloRiferimento;

        public Modello ModelloRiferimento { get => _modelloRiferimento; set => _modelloRiferimento = value; }

        protected Documento()
        {

        }

        #endregion
    }
}
