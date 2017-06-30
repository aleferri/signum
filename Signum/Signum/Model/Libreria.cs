using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public interface ILibreria
    {
        IEnumerable<ImmagineFissa> ImmaginiFisse { get; }
        IEnumerable<Animazione> Animazioni { get; }
    }
}
