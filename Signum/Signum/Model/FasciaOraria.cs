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

        public FasciaOraria(uint startQuarter, uint endQuarter)
        {
            _startQuarter = startQuarter;
            _endQuarter = endQuarter;
        }

        public uint StartQuarter => _startQuarter;

        public uint EndQuarter => _endQuarter;

    }
}
