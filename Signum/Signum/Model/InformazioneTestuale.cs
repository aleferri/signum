using System;

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
        public IInformazione Copy()
        {
            return new InformazioneTestuale(String.Copy(_value));
        }
    }
}
