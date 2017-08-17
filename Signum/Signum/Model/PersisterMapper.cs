using Signum.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public abstract class PersisterMapper : ICopiable<PersisterMapper>
    {
        public int ID { get; }
        public object Element { get; }
        protected PersisterMapper(object obj, int id)
        {
            ID = id;
            Element = obj;
        }

        public PersisterMapper Copy()
        {
            Type t = Element.GetType();
            Type makeme = GetType();
            return (PersisterMapper) Activator.CreateInstance(makeme, new object[] { ((Common.ICopiable)Element).Copy(), ID });
        }

        object ICopiable.Copy()
        {
            return Copy();
        }
    }

    public class PersisterMapper<W> : PersisterMapper, ICopiable<PersisterMapper<W>> where W : ICopiable<W>
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

        PersisterMapper<W> ICopiable<PersisterMapper<W>>.Copy()
        {
            return new PersisterMapper<W>(_element.Copy(), ID);
        }
        object ICopiable.Copy()
        {
            return Copy();
        }
    }
}
