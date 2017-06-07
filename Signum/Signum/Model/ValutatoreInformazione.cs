using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    class ValutatoreInformazione : IValutatoreInformazione<string>
    {
        public string visit(Informazione info)
        {
            return info.Valore;
        }

        public string visit(InformazioneDataOra info)
        {
            return DateTime.Now.ToString();
        }
    }
}
