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

        public ProgrammazioneSettimanale()
        {
            _programma = new ProgrammazioneGiornaliera[7];
        }

        public void SetProgrammazione(ProgrammazioneGiornaliera p, DayOfWeek day)
        {
            _programma[(int)day] = p;
        }

        public ProgrammazioneGiornaliera GetProgrammazione(DayOfWeek day)
        {
            return _programma[(int)day];
        }

    }
}
