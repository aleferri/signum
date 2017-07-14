using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class ModelToPersistenceWrapper<W>
    {
        private readonly int _id;
        private readonly W _element;

        public int ID { get; }
        public W ModelElement => _element;

        public ModelToPersistenceWrapper(W modelElement, int id)
        {
            ID = id;
            _element = modelElement;
        }
        public ModelToPersistenceWrapper(W modelElement)
        {
            ID = -1;
            _element = modelElement;
        }
    }
}
