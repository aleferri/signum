
namespace ModelManaging
{
    [NameAttribute("Modello Rettangolare")]
    public class ModelloRettangolare: Modello
    {

        public ModelloRettangolare(int larghezza, int altezza) : base(larghezza, altezza)
        {
        }

        public override string ToString()
        {
            return "Modello a Rettangolo " + base.ToString();
        }
    }
}
