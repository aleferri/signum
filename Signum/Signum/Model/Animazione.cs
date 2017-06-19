using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    class Animazione : IElemento
    {
        private int _frameRate;
        private readonly List<Frame> _frameSequence;
        private IInformazione _informazione;

        public Frame this[int position]
        {
            get => _frameSequence[position];
            set => _frameSequence[position] = value;
        }
        public int Durata => _frameSequence.Count() / _frameRate;
        public IInformazione InfomazioneAssociata
        {
            get => _informazione;
            set => _informazione = value;
        }

        public Animazione(int frameRate)
        {
            Debug.Assert(frameRate > 0);
            _frameRate = frameRate;
        }
    }
}
