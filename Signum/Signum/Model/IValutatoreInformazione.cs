using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public interface IValutatoreInformazione<T>
    {
        T visit(InformazioneTestuale info);

        T visit(InformazioneDataOra info);
    }
}
