using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Presentation.EditorsHandling
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    class NameTagAttribute : Attribute
    {
        public string Name { get; }
        public string Tag { get; }

        public NameTagAttribute(string name, string tag)
        {
            Name = name;
            Tag = tag;
        }

        public NameTagAttribute(string name) : this(name, name)
        {

        }
    }
}
