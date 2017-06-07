using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    abstract class Informazione
    {

        private string _value;

        public Informazione(string value)
        {
            _value = value;
        }

        public virtual string Value {
            get {
                return _value;
            }
            protected set
            {
                _value = Value;
            }
        }

    }
}
