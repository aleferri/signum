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
           
            // Frame
            if (br.ReadString() != typeof(ImmagineFissa).GetType().ToString()) throw new FileLoadException("Tipo non compatibile");
            int len = br.ReadInt32();
            byte[] frameToArray = new byte[len];
            br.Read(frameToArray, 0, len);

            // Informazione
            IPersister infoPersister = PersisterFactory.GetPersister(br.ReadString());
            if (!(infoPersister.GetType().GetGenericTypeDefinition() is IInformazione)) throw new FileLoadException("Informazione associata non compatibile");

            IInformazione infoAssociata = (IInformazione)infoPersister.Retrive(br);

            // Manca costruttpre ByteArray -> Frame
            throw new NotImplementedException();
        }

        public void Save(ImmagineFissa elem, BinaryWriter bw)
        {
            // Modello di riferimento
            Modello modello = Documento.getInstance().ModelloRiferimento;
            bw.Write(modello.Size.Width);
            bw.Write(modello.Size.Height);
            
            // Frame
            bw.Write(elem.GetType().ToString());
            byte[] frameToArray = elem.Frame.ToByteArray();
            bw.Write(frameToArray.Length);
            bw.Write(frameToArray);

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
