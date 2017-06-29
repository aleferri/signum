using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public abstract class Elemento
    {
        private IInformazione _informazione;
        public virtual IInformazione InformazioneAssociata {
            get => _informazione;
            set => _informazione = value ?? new InformazioneDataOra();
        }

        protected Elemento()
        {
            _informazione = new InformazioneDataOra();
        }

        public abstract override string ToString();

    }
}
