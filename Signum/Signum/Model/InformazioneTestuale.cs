using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class InformazioneTestuale: IInformazione
    {

        private readonly string _value;

        public string Valore => _value;

        public InformazioneTestuale(string info)
        {
            _value = info;
        }

        public T Accept<T>(IValutatoreInformazione<T> valutatore)
        {
            return valutatore.Visit(this);
        }
    }
}
