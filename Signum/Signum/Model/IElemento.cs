using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    interface IElemento
    {

        int Durata { get; }

        Informazione InfomazioneAssociata { get; }

    }
}
