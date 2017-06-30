using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class ImmagineFissa : Elemento
    {
        private readonly Frame _frame;

        public Frame Frame => _frame;

        public ImmagineFissa(Frame frame, IInformazione informazione)
        {
            _frame = frame;
            InformazioneAssociata = informazione;
        }

        public ImmagineFissa(Frame frame) : this(frame, null)
        { 
        }

        public override string ToString()
        {
            return String.Format("Immagine fissa -> \"{0}\"", InformazioneAssociata.Accept(new ValutatoreInformazione()));
        }
    }
}
