using System;

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

        public ModelloCroce(int braccioX, int larghezzaX, int braccioY, int larghezzaY):
            base(braccioX * 2 + larghezzaX, braccioY * 2 + larghezzaY)
        {
            if(0 == larghezzaX || 0 == larghezzaY || 0 == braccioX || 0 == braccioY)
            {
                throw new ArgumentException("Non sono ammesse dimensioni nulle");
            }

            _centerX = larghezzaX;
            _centerY = larghezzaY;
            _wingX = braccioX;
            _wingY = braccioY;
        }

        public override string ToString()
        {
            return "Modello a Croce " + base.ToString();
        }
    }
}
