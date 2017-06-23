﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public struct Frame
    {
        private BitArray _bitmap;
        private readonly int _nCols;

        public Size Size => new Size(_nCols, _bitmap.Count / _nCols);
        public bool this[int x, int y] {
            get => _bitmap[x + y * _nCols];
            set => _bitmap[x + y * _nCols] = value;
        }

        public Frame(int x, int y)
        {
            _bitmap = new BitArray(x * y, false);
            _nCols = x;
        }
    }
}