using ModelManaging;
using Signum.Model;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Signum.Persistence
{
    [TypeAttribute(typeof(ImmagineFissa))]
    internal class ImmagineFissaPersister : IPersister<ImmagineFissa>
    {
        public ImmagineFissa Retrieve(BinaryReader br)
        {
            // Immagine
            string nome = br.ReadString();

            // Modello
            Modello modello = Documento.getInstance().ModelloRiferimento;
            int width = br.ReadInt32();
            int height = br.ReadInt32();
            if (width != modello.Size.Width || height != modello.Size.Height) return null;    

            // Frame
            int nCol = br.ReadInt32();
            int len = br.ReadInt32();
            byte[] frameAsArray = new byte[len];
            br.Read(frameAsArray, 0, len);

            // Informazione
            IPersister infoPersister = PersisterFactory.GetPersister(br.ReadString());
            TypeAttribute attr = (TypeAttribute)infoPersister.GetType().GetCustomAttribute(typeof(TypeAttribute));
            IInformazione infoAssociata = (IInformazione)infoPersister.Retrieve(br);

            // Out
            ImmagineFissa result = new ImmagineFissa(new Frame(frameAsArray, nCol, width * height), infoAssociata, nome);
            return result;
        }

        public void Save(ImmagineFissa elem, BinaryWriter bw)
        {
            // Immagine
            bw.Write(elem.GetType().ToString());
            bw.Write(elem.Nome);

            // Modello di riferimento
            Modello modello = Documento.getInstance().ModelloRiferimento;
            bw.Write(modello.Size.Width);
            bw.Write(modello.Size.Height);
            
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
            Save((ImmagineFissa)elem, bw);
        }

        object IPersister.Retrieve(BinaryReader br)
        {
            return Retrieve(br);
        }
    }
}
