
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
        public ModelloEllisse(int diametroX, int diametroY) : base(diametroX, diametroY)
        {
        }

        public override string ToString()
        {
            return "Modello a Ellisse " + base.ToString();
        }
    }
}
