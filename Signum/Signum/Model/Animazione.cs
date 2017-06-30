using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class Animazione : Elemento
    {
        private uint _frameRate;
        private readonly List<Frame> _frameSequence;

        public Frame this[int position]
        {
            get => _frameSequence[position];
            set => _frameSequence[position] = value;
        }
        public ulong Durata => (ulong)_frameSequence.Count() / _frameRate;

        public Animazione(uint frameRate, IInformazione informazione)
        {
            Debug.Assert(frameRate > 0);
            _frameRate = frameRate;
            _frameSequence = new List<Frame>();
            InformazioneAssociata = informazione;
        }

        public Animazione(uint frameRate) : this(frameRate, null)
        {
        }

        public override string ToString()
        {
            return String.Format("Animazione -> \"{0}", InformazioneAssociata.Accept(new ValutatoreInformazione()));
        }
    }
}
