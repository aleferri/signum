using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    class ProgrammazioneSettimanale
    {

        private readonly ProgrammazioneGiornaliera[] _programma;

        public ProgrammazioneGiornaliera this[DayOfWeek day]
        {
            get => _programma[(int)day];
            set => _programma[(int)day] = value;
        }

        public ProgrammazioneSettimanale()
        {
            _programma = new ProgrammazioneGiornaliera[7];
        }

    }
}
