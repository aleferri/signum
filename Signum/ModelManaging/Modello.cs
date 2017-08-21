using System;
using System.Drawing;

namespace ModelManaging
{
    /// <summary>
    /// Classe base per la gestione dei Modelli di'insegna. Ogni classe da questa derivante identifica un diverso modello
    /// </summary>
    public abstract class Modello
    {
        private readonly Size _rectangularSize;
        public virtual bool this[int row, int col] => true;
        public virtual Size Size => _rectangularSize;

        protected Modello(int sizeX, int sizeY)
        {
            if(0 == sizeX || 0 == sizeY)
            {
                throw new ArgumentException("Non sono ammesse dimensioni nulle");
            }
            _rectangularSize = new Size(sizeX, sizeY);
        }

        public override string ToString()
        {
            return String.Format("({0} x {1})", this.Size.Width, this.Size.Height);
        }
    }
}
