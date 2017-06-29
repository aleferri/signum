using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class Sequenza
    {
        private List<KeyValuePair<Elemento, uint>> _elementi;

        public KeyValuePair<Elemento, uint> this[int index] => _elementi[index];

        public Sequenza()
        {
            _elementi = new List<KeyValuePair<Elemento, uint>>();
        }
 
        public void AggiungiElemento(Elemento elemento, uint durata)
        {
            Debug.Assert(null != elemento);
            Debug.Assert(0 < durata);
            _elementi.Add(new KeyValuePair<Elemento, uint>(elemento, durata));
        }
        public void InserisciElemento(Elemento elemento, uint durata, int index)
        {
            Debug.Assert(null != elemento);
            Debug.Assert(0 < durata);
            _elementi.Insert(index, new KeyValuePair<Elemento, uint>(elemento, durata));
        }

        public void EliminaElemento(int index)
        {
            _elementi.RemoveAt(index);
        }
    }

}
