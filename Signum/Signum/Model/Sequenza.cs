using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class Sequenza
    {
        private List<SequenzaWrapper> _elementi;

        public IElemento this[int index] => _elementi[index].Elemento;

        public Sequenza()
        {

        }
 
        #region Wrapper
        private class SequenzaWrapper
        {
            private readonly IElemento _elemento;
            private uint _durata;

            public uint Durata { get => _durata; set => _durata = value; }
            public IElemento Elemento => _elemento;

            public SequenzaWrapper(IElemento elemento)
            {
                _elemento = elemento;
            }
        }
        #endregion
    }

}
