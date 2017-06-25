using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class InformazioneTestuale: IInformazione
    {

        private string _value;

        public string Valore => _value;

        public T accept<T>(IValutatoreInformazione<T> valutatore)
        {
            return valutatore.visit(this);
        }
    }
}
