using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Common
{
    public interface ICopiable
    {
        object Copy();
    }

    public interface ICopiable<T> : ICopiable
    {
        new T Copy();
    }
}
