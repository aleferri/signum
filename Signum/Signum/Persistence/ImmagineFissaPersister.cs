using ModelManaging;
using Signum.Model;
using System;
using System.IO;
using System.Text;

namespace Signum.Persistence
{
    [TypeAttribute(typeof(ImmagineFissa))]
    internal class ImmagineFissaPersister : IPersister<ImmagineFissa>
    {
        public ImmagineFissa Retrive(BinaryReader br)
        {
            // Modello
            Modello modello = Documento.getInstance().ModelloRiferimento;
            int width = br.ReadInt32();
            int height = br.ReadInt32();
            if (width != modello.Size.Width || height != modello.Size.Height) throw new FileLoadException("Modello non compatibile");
           
            // Immagine
            if (br.ReadString() != typeof(ImmagineFissa).GetType().ToString()) throw new FileLoadException("Tipo non compatibile");
            string nome = br.ReadString();
            // Frame
            int nCol = br.ReadInt32();
            int len = br.ReadInt32();
            byte[] frameAsArray = new byte[len];
            br.Read(frameAsArray, 0, len);

            // Informazione
            IPersister infoPersister = PersisterFactory.GetPersister(br.ReadString());
            if (!(infoPersister.GetType().GetCustomAttributes(false)[0] is IInformazione)) throw new FileLoadException("Informazione associata non compatibile");
            IInformazione infoAssociata = (IInformazione)infoPersister.Retrive(br);

            // Out
            ImmagineFissa result = new ImmagineFissa(new Frame(frameAsArray, nCol), infoAssociata);
            result.Nome = nome;
            return result;
        }

        public void Save(ImmagineFissa elem, BinaryWriter bw)
        {
            // Modello di riferimento
            Modello modello = Documento.getInstance().ModelloRiferimento;
            bw.Write(modello.Size.Width);
            bw.Write(modello.Size.Height);
            
            // Immagine
            bw.Write(elem.GetType().ToString());
            bw.Write(elem.Nome);
            // Frame
            byte[] frameAsArray = elem.Frame.ToByteArray();
            bw.Write(elem.Frame.Size.Width);
            bw.Write(frameAsArray.Length);
            bw.Write(frameAsArray);

            // Informazione
            IPersister infoPersister = PersisterFactory.GetPersister(elem.InformazioneAssociata.GetType());
            infoPersister.Save(elem.InformazioneAssociata, bw);

        }

        void IPersister.Save(object elem, BinaryWriter bw)
        {
            if (!(elem is ImmagineFissa)) throw new ArgumentException();
            this.Save((ImmagineFissa)elem, bw);
        }

        object IPersister.Retrive(BinaryReader br)
        {
            return this.Retrive(br);
        }
    }
}
