using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManaging
{
    [NameAttribute("Modello Rettangolare")]
    public class ModelloRettangolare: Modello
    {

        public ModelloRettangolare(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
        }

        public override string ToString()
        {
            return base.ToString() + " (Modello a Rettangolo) ";
        }
    }
}
