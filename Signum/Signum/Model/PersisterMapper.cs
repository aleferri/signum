using Signum.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class PersisterMapper
    {
        public int ID { get; }
        public object Element { get; }
        protected PersisterMapper(object obj, int id)
        {
            ID = id;
            Element = obj;
        }
    }

    public class PersisterMapper<W> : PersisterMapper where W : ICopiable<W> 
    {
        private readonly W _element;

        new public W Element => _element;

        public PersisterMapper(W modelElement, int id) : base(modelElement, id)
        {
            _element = modelElement;
        }
        public PersisterMapper(W modelElement) : this(modelElement, -1)
        {
        }
    }
}
