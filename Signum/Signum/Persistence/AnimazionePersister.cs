using ModelManaging;
using Signum.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Persistence
{
    [TypeAttribute(typeof(Animazione))]
    internal class AnimazionePersister : IPersister<Animazione>
    {
        public Animazione Retrieve(BinaryReader br)
        {
            // Animazione
            string nome = br.ReadString();
            uint frameRate = br.ReadUInt32();
            Animazione result = new Animazione(frameRate);
            result.Nome = nome;

            // Modello
            Modello modello = Documento.getInstance().ModelloRiferimento;
            int width = br.ReadInt32();
            int height = br.ReadInt32();
            if (width != modello.Size.Width || height != modello.Size.Height) return null;

            // Frames
            byte[] frameAsArray;
            int nFrames = br.ReadInt32();
            for(int i=0; i<nFrames; i++)
            {
                int nCol = br.ReadInt32();
                int len = br.ReadInt32();
                frameAsArray = new byte[len];
                br.Read(frameAsArray, 0, len);
                result.Frames.Add(new Frame(frameAsArray, nCol, width*height));
            }
            

            // Informazione
            IPersister infoPersister = PersisterFactory.GetPersister(br.ReadString());
            IInformazione infoAssociata = (IInformazione)infoPersister.Retrieve(br);

            // Out
            result.InformazioneAssociata = infoAssociata;
            return result;
        }

        public void Save(Animazione elem, BinaryWriter bw)
        {
            // Animazione
            bw.Write(elem.GetType().ToString());
            bw.Write(elem.Nome);
            bw.Write(elem.FrameRate);

            // Modello di riferimento
            Modello modello = Documento.getInstance().ModelloRiferimento;
            bw.Write(modello.Size.Width);
            bw.Write(modello.Size.Height);

            // Frames
            bw.Write(elem.Frames.Count);
            byte[] frameAsArray;
            foreach (Frame frame in elem.Frames)
            {
                frameAsArray = frame.ToByteArray();
                bw.Write(frame.Size.Width);
                bw.Write(frameAsArray.Length);
                bw.Write(frameAsArray);
            }

            // Informazione
            IPersister infoPersister = PersisterFactory.GetPersister(elem.InformazioneAssociata.GetType());
            infoPersister.Save(elem.InformazioneAssociata, bw);
        }

        void IPersister.Save(object elem, BinaryWriter bw)
        {
            if (!(elem is Animazione)) throw new ArgumentException();
            this.Save((Animazione)elem, bw);
        }

        object IPersister.Retrieve(BinaryReader br)
        {
            return this.Retrieve(br);
        }
    }
}
