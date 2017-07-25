using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class FasciaOraria
    {

        public static FasciaOraria FromDateTime(DateTime start, DateTime end)
        {
            return new FasciaOraria((uint)(start.Hour * 60 / 15 + start.Minute / 15), (uint)(end.Hour * 60 / 15 + end.Minute / 15));
        }

        private readonly uint _startQuarter;
        private readonly uint _endQuarter;

        public uint StartQuarter => _startQuarter;
        public uint EndQuarter => _endQuarter;
        public uint CoveredQuarters => _endQuarter - _startQuarter;

        public FasciaOraria(uint startQuarter, uint endQuarter)
        {
            if (endQuarter < startQuarter) throw new ArgumentException("In una fascia oraria il limite superiore non può essere minore del limite inferiore");
            _startQuarter = startQuarter;
            _endQuarter = endQuarter;
        }

        public int StartHourEquivalent()
        {
            return (int)_startQuarter * 15 / 60;
        }
        public int StartMinuteEquivalent()
        {
            return (int)_startQuarter * 15 % 60;
        }
        public int EndHourEquivalent()
        {
            return (int)_endQuarter * 15 / 60;
        }
        public int EndMinuteEquivalent()
        {
            return (int)_endQuarter * 15 % 60;
        }
        public override string ToString()
        {
            return _startQuarter + " -> " + _endQuarter;
        }
    }
}
