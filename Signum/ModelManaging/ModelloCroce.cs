using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManaging
{
    [NameAttribute("Modello a Croce")]
    public class ModelloCroce : Modello
    {
        private readonly int _centerX, _centerY, _wingX, _wingY;

        public override bool this[int row, int col]
        {
            get
            {
                bool isOutY = col < _wingY || col >= _wingY + _centerY;
                if ((row < _wingX || row >= _wingX + _centerX) && isOutY ) return false;
                return true;
            }
        }

        public ModelloCroce(int wingX, int centerX, int wingY, int centerY):
            base(wingX * 2 + centerX, wingY * 2 + centerY)
        {
            if(0 == centerX || 0 == centerY || 0 == wingX || 0 == wingY)
            {
                throw new ArgumentException("Non sono ammesse dimensioni nulle");
            }

            _centerX = centerX;
            _centerY = centerY;
            _wingX = wingX;
            _wingY = wingY;
        }

        public override string ToString()
        {
            return base.ToString() + " (Modello a Croce) ";
        }
    }
}
