using System;
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
        private static bool[] FromBytesToBool(byte[] array, int realLength)
        {
            bool[] result = new bool[realLength];
            int shifter;
            int index;
            for (int i = 0; i < realLength; i++)
            {
                shifter = i % 8;
                index = i / 8;
                result[i] = !((array[index] & (1 << shifter)) == 0);
            }
            return result;
        }

        private BitArray _bitmap;
        private readonly int _nCols;

        public Size Size => new Size(_nCols, _bitmap.Count / _nCols);
        public bool this[int x, int y] {
            get => _bitmap[x + y * _nCols];
            set =>  _bitmap[x + y * _nCols] = value;
        }

        private Frame(bool[] bitArray, int nCols)
        {
            _bitmap = new BitArray(bitArray);
            _nCols = nCols;
        }
        public Frame(int x, int y)
        {
            _bitmap = new BitArray(x * y, false);
            _nCols = x;
        }
        public Frame(Size size) : this(size.Width, size.Height)
        {
        }
        public Frame(byte[] array, int nCols, int bitcount) : this(FromBytesToBool(array, bitcount), nCols)
        {
        }

        public byte[] ToByteArray()
        {
            byte[] result = new byte[(_bitmap.Count - 1) / 8 + 1];
            _bitmap.CopyTo(result, 0);
            return result;
        }

        public bool[] ToBoolArray()
        {
            bool[] result = new bool[_bitmap.Count];
            for(int i = 0; i < _bitmap.Count; i++)
            {
                result[i] = _bitmap[i];
            }
            return result;
        }

        public Frame Copy()
        {
            return new Frame(ToBoolArray(), _nCols);
        }
    }
}
