using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManaging
{
    [NameAttribute("Modello a Ellisse")]
    public class ModelloEllisse : Modello
    {

        public override bool this[int row, int col]
        {
            get
            {
                return 1 >= (row - Size.Width / 2) * (row - Size.Width / 2) / (Size.Width * Size.Width/ 4.0) + (col - Size.Height / 2) * (col - Size.Height / 2) /(Size.Height * Size.Height / 4.0);
            }
        }
        public ModelloEllisse(int dX, int dY) : base(dX, dY)
        {
        }

        public override string ToString()
        {
            return base.ToString() + " (Modello a Ellisse) ";
        }
    }
}
