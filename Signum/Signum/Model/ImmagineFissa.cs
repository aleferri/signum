using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class ImmagineFissa : Elemento
    {
        private static ImmagineFissa defaultImage;

        public static ImmagineFissa Empty => (ImmagineFissa)defaultImage.Copy();

        static ImmagineFissa()
        {
            Documento.getInstance().ModelChanged += OnModelChange;
            OnModelChange(null, new ModelEventArgs(Documento.getInstance().ModelloRiferimento));
        }

        private static void OnModelChange(object sender, ModelEventArgs args)
        {
            defaultImage = new ImmagineFissa(new Frame(args.NuovoModello.Size));
            defaultImage.Nome = "<immagine fissa>";
            defaultImage.InformazioneAssociata = new InformazioneTestuale("");
        }

        private readonly Frame _frame;

        public Frame Frame => _frame;

        public ImmagineFissa(Frame frame, IInformazione informazione, string nome)
        {
            _frame = frame;
            InformazioneAssociata = informazione;
            Nome = nome;
        }

        public ImmagineFissa(Frame frame, IInformazione informazione) : this(frame, informazione, "")
        {
        }

        public ImmagineFissa(Frame frame) : this(frame, null)
        { 
        }

        public override Elemento Copy()
        {
            return new ImmagineFissa(new Frame(_frame.Size), InformazioneAssociata, Nome);
        }

        public override string ToString()
        {
            return String.Format("Immagine fissa -> \"{0}\"", InformazioneAssociata.Accept(new ValutatoreInformazione()));
        }
    }
}
