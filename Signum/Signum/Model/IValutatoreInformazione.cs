using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public interface IValutatoreInformazione<T>
    {
        /// <summary>
        /// Visita una informazione testuale
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        T Visit(InformazioneTestuale info);
        /// <summary>
        /// Visita una informazione data e ora
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        T Visit(InformazioneDataOra info);
    }
}
