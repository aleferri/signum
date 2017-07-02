using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public abstract class Elemento
    {
        private string _nome;
        private IInformazione _informazione;
        public virtual IInformazione InformazioneAssociata {
            get => _informazione;
            set => _informazione = value ?? new InformazioneDataOra();
        }

        public string Nome
        {
            get => _nome;
            set => _nome = value ?? String.Format("Elemento_{0}_{1}", DateTime.Now.ToShortDateString().Replace("/", "-"), DateTime.Now.ToShortTimeString().Replace(":", ""));
        }

        protected Elemento()
        {
            _informazione = new InformazioneDataOra();
        }

        public abstract override string ToString();

    }

    public class ElementoDummy : Elemento
    {

        public static readonly ElementoDummy DUMMY = new ElementoDummy();

        private ElementoDummy()
        {

        }

        public override string ToString()
        {
            return "Nessun Elemento";
        }
    }
}
