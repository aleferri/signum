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
        public Animazione Retrive(BinaryReader br)
        {
            // Modello
            Modello modello = Documento.getInstance().ModelloRiferimento;
            int width = br.ReadInt32();
            int height = br.ReadInt32();
            if (width != modello.Size.Width || height != modello.Size.Height) throw new FileLoadException("Modello non compatibile");

            // Animazione
            if (br.ReadString() != typeof(Animazione).GetType().ToString()) throw new FileLoadException("Tipo non compatibile");
            string nome = br.ReadString();
            uint frameRate= br.ReadUInt32();
            Animazione result = new Animazione(frameRate);
            result.Nome = nome;
            // Frames
            byte[] frameAsArray;
            int nFrames = br.ReadInt32();
            for(int i=0; i<nFrames; i++)
            {
                int nCol = br.ReadInt32();
                int len = br.ReadInt32();
                frameAsArray = new byte[len];
                br.Read(frameAsArray, 0, len);
                result.Frames.Add(new Frame(frameAsArray, nCol));
            }
            

            // Informazione
            IPersister infoPersister = PersisterFactory.GetPersister(br.ReadString());
            if (!(infoPersister.GetType().GetCustomAttributes(false)[0] is IInformazione)) throw new FileLoadException("Informazione associata non compatibile");
            IInformazione infoAssociata = (IInformazione)infoPersister.Retrive(br);

            // Out
            result.InformazioneAssociata = infoAssociata;
            return result;
        }

        public void Save(Animazione elem, BinaryWriter bw)
        {
            // Modello di riferimento
            Modello modello = Documento.getInstance().ModelloRiferimento;
            bw.Write(modello.Size.Width);
            bw.Write(modello.Size.Height);

            // Animazione
            bw.Write(elem.GetType().ToString());
            bw.Write(elem.Nome);
            bw.Write(elem.FrameRate);
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

        object IPersister.Retrive(BinaryReader br)
        {
            return this.Retrive(br);
        }
    }
}
