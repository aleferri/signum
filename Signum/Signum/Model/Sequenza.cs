using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{ 

    public class Sequenza :IListSource
    {

        public static readonly uint MAX_DURATION = 60 * 60 * 24;
        private string _nome;
        private List<KeyValuePair<Elemento, uint>> _elementi;

        public uint Durata => (uint)_elementi.Sum(e => e.Value);
        public int Count => _elementi.Count;
        public string Nome
        {
            get => _nome;
            set => _nome = value ?? "Nuova sequenza";
        }
        public bool ContainsListCollection => true;

        public Elemento this[int index] => _elementi[index].Key;

        public Sequenza()
        {
            _elementi = new List<KeyValuePair<Elemento, uint>>();
        }

        public void AggiungiElemento(Elemento elemento, uint durata)
        {
            Debug.Assert(null != elemento);
            _elementi.Add(new KeyValuePair<Elemento, uint>(elemento, durata));
        }
        public void InserisciElemento(Elemento elemento, uint durata, int index)
        {
            Debug.Assert(null != elemento);
            Debug.Assert(0 < durata);
            _elementi.Insert(index, new KeyValuePair<Elemento, uint>(elemento, durata));
        }

        public uint GetDurataOf(Elemento elemento)
        {
            for(int i = 0; i < _elementi.Count; i++)
            {
                if (elemento == _elementi[i].Key) return _elementi[i].Value;
            }
            throw new KeyNotFoundException("Nessun elemento corrispondente trovato");
        }

        public void EliminaElemento(int index)
        {
            _elementi.RemoveAt(index);
        }

        public IList GetList()
        {
            return (from KeyValuePair<Elemento, uint> pair
                    in _elementi
                    select pair.Key).ToList();
        }
    }

}
