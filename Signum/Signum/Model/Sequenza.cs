using Signum.Common;
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

    public class Sequenza : IListSource, ICopiable<Sequenza>
    {

        public static readonly uint MAX_DURATION = 60 * 60 * 24;

        private string _nome;
        private List<KeyValuePair<Elemento, uint>> _elementi;

        public uint Durata => (uint)_elementi.Sum(e => e.Value);
        public bool ContainsListCollection => true;
        public Elemento this[int index] => _elementi[index].Key;
        public int Count => _elementi.Count;

        public string Nome
        {
            get => _nome;
            set => _nome = value ?? String.Format("Sequenza_{0}_{1}", DateTime.Now.ToShortDateString().Replace("/", "-"), DateTime.Now.ToShortTimeString().Replace(":", ""));
        }

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
        public void EliminaElemento(int index)
        {
            _elementi.RemoveAt(index);
        }
        public uint GetDurataOf(Elemento elemento)
        {
            return (from KeyValuePair<Elemento, uint> kvp
                    in _elementi
                    where kvp.Key == elemento
                    select kvp.Value)
                    .Single();
        }
        public uint GetDurataOf(int index)
        {
            return (from KeyValuePair<Elemento, uint> kvp
                    in _elementi
                    where _elementi.IndexOf(kvp) == index
                    select kvp.Value)
                    .Single();
        }
        public void SetDurataOf(Elemento elemento, uint durata)
        {
            int index = IndexOf(elemento);
            if (index != -1)
                _elementi[index] = new KeyValuePair<Elemento, uint>(elemento, durata);
        }
        public void SetDurataOf(int index, uint durata)
        {
            SetDurataOf(this[index], durata);
        }
        public int IndexOf(Elemento e)
        {
            for(int i = 0; i < _elementi.Count; i++)
            {
                if (_elementi[i].Key == e) return i;
            }
            return -1;
        }
        public Sequenza Copy()
        {
            Sequenza s = new Sequenza();
            s.Nome = Nome;
            _elementi.ForEach(e => s.AggiungiElemento(e.Key.Copy(), e.Value));
            return s;
        } 

        public IList GetList()
        {
            return (from KeyValuePair<Elemento, uint> pair
                    in _elementi
                    select pair.Key).ToList();
        }
    }

}
