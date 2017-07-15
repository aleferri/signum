using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class ModelToPersistenceWrapper
    {
        private readonly int _id;
        private readonly object _objElement;

        public int ID { get; }
        public object ObjectModelElement => _objElement;

        protected ModelToPersistenceWrapper(object objModel, int id)
        {
            _id = id;
            _objElement = objModel;
        }
    }

    public class ModelToPersistenceWrapper<W> : ModelToPersistenceWrapper
    {
        private readonly W _element;       
        public W ModelElement => _element;

        public ModelToPersistenceWrapper(W modelElement, int id) : base(modelElement, id)
        {
            _element = modelElement;
        }
        public ModelToPersistenceWrapper(W modelElement) : this(modelElement, -1)
        {
        }
    }
}
