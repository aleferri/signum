﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManaging
{
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
            return String.Format("TOT[{0}, {1}]", this.Size.Width, this.Size.Height);
        }
    }
}