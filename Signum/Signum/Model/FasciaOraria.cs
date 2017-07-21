using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class FasciaOraria
    {

        private readonly uint _startQuarter;
        private readonly uint _endQuarter;

        public uint StartQuarter => _startQuarter;
        public uint EndQuarter => _endQuarter;

        public FasciaOraria(uint startQuarter, uint endQuarter)
        {
            if (endQuarter < startQuarter) throw new ArgumentException("In una fascia oraria il limite superiore non può essere minore del limite inferiore");
            _startQuarter = startQuarter;
            _endQuarter = endQuarter;
        }

        public override string ToString()
        {
            return _startQuarter + " -> " + _endQuarter;
        }
    }
}
