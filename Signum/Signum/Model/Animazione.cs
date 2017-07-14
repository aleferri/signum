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
        private static Animazione defaultAnimazione;
        public static Animazione Empty => (Animazione)defaultAnimazione.Copy();

        static Animazione()
        {
            Documento.getInstance().ModelChanged += OnModelChange;
            OnModelChange(null, new ModelEventArgs(Documento.getInstance().ModelloRiferimento));
        }

        private static void OnModelChange(object sender, ModelEventArgs args)
        {
            defaultAnimazione = new Animazione(10)
            {
                Nome = "<animazione>",
                InformazioneAssociata = new InformazioneTestuale("")
            };
            defaultAnimazione.Frames.Add(new Frame(args.NuovoModello.Size));
        }

        private uint _frameRate;
        private readonly List<Frame> _sequenzaFrame;

        public List<Frame> Frames => _sequenzaFrame;
        public ulong Durata => (ulong)_sequenzaFrame.Count() / _frameRate;
        public uint FrameRate
        {
            get => _frameRate;
            set => _frameRate = value;
        }
        public Animazione(uint frameRate, IInformazione informazione)
        {
            _frameRate = frameRate;
            _sequenzaFrame = new List<Frame>();
            InformazioneAssociata = informazione;
        }

        public Animazione(uint frameRate) : this(frameRate, null)
        {
        }

        public override Elemento Copy()
        {
            Animazione result = new Animazione(_frameRate, InformazioneAssociata);
            _sequenzaFrame.ForEach(f => result.Frames.Add(f.Copy()));
            result.Nome = Nome;
            return result;
        }
        public override string ToString()
        {
            return String.Format("Animazione -> \"{0}", InformazioneAssociata.Accept(new ValutatoreInformazione()));
        }
    }
}
