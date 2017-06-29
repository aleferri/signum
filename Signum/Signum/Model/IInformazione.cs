using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public interface IInformazione
    {
         T Accept<T>(IValutatoreInformazione<T> valutatore);
    }
}
