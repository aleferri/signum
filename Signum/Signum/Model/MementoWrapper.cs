using Signum.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class MementoWrapper
    {

        private readonly int _id;
        private IList _objElements;
        protected int _current;

        public int ID { get; }
        public object ObjectModelElement => _objElements[_current];
        public int Count => _objElements.Count;
        public int CurrentIndex => _current;

        protected MementoWrapper(int id)
        {
            _id = id;
        }

        protected void SetList(IList list)
        {
            _objElements = list;
        }
    }

    public class MementoWrapper<W> : MementoWrapper where W : ICopiable<W> 
    {
        public event EventHandler MementoChange;

        private readonly List<W> _elements;

        public W Memento => _elements[_current].Copy();

        public MementoWrapper(W modelElement, int id) : base(id)
        {
            _elements = new List<W>();
            SetList(_elements);
            _elements.Add(modelElement);
            _current = 0;
        }
        public MementoWrapper(W modelElement) : this(modelElement, -1)
        {
        }

        public bool CanGoBack()
        {
            return CurrentIndex > 0;
        }
        public bool CanGoForward()
        {
            return CurrentIndex < Count - 1;
        }
        public void Back()
        {
            if (_current > 0)
            {
                _current--;
                MementoChange?.Invoke(this, EventArgs.Empty);
            }
        }
        public void Forward()
        {
            if (_current < _elements.Count - 1)
            {
                _current++;
                MementoChange?.Invoke(this, EventArgs.Empty);
            }
        }
        public void AddStep(W step)
        {
            if(_current < _elements.Count - 1)
            {
                _elements.RemoveAll(e => _elements.IndexOf(e) > _current);
            }
            _elements.Add(step);
            _current++;
            MementoChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
