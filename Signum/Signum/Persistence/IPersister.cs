using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Persistence
{
    public interface IPersister
    { 
    }
    public interface IPersister<T> : IPersister
    {
        void Save(T element);
        T Retrieve(string fileName);
    }
}
