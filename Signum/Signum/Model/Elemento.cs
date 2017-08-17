using Signum.Common;
using System;

namespace Signum.Model
{
    public abstract class Elemento : ICopiable<Elemento>
    {
        public static Elemento Default => ImmagineFissa.Empty;

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
        public abstract Elemento Copy();
        object ICopiable.Copy()
        {
            return Copy();
        }
    }

    public class ElementoDummy : Elemento
    {

        public static readonly ElementoDummy DUMMY = new ElementoDummy();

        private ElementoDummy()
        {

        }

        public override Elemento Copy()
        {
            return DUMMY;
        }
        public override string ToString()
        {
            return "Nessun Elemento";
        }
    }
}
