using Signum.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    class ProgrammazioneSettimanale : Elemento, ICopiable<ProgrammazioneSettimanale>
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

        public override Elemento Copy()
        {
            return ((ICopiable<ProgrammazioneSettimanale>)this).Copy();
        }

        ProgrammazioneSettimanale ICopiable<ProgrammazioneSettimanale>.Copy()
        {
            ProgrammazioneSettimanale p = new ProgrammazioneSettimanale();
            p[DayOfWeek.Friday] = this[DayOfWeek.Friday];
            p[DayOfWeek.Monday] = this[DayOfWeek.Monday];
            p[DayOfWeek.Saturday] = this[DayOfWeek.Saturday];
            p[DayOfWeek.Sunday] = this[DayOfWeek.Sunday];
            p[DayOfWeek.Thursday] = this[DayOfWeek.Thursday];
            p[DayOfWeek.Tuesday] = this[DayOfWeek.Tuesday];
            p[DayOfWeek.Wednesday] = this[DayOfWeek.Wednesday];
            return p;
        }

        public override string ToString()
        {
            return "ProgrammazioneSettimanale";
        }

    }
}
