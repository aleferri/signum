using ModelManaging;
using Signum.Model;
using System;
using System.IO;
using System.Text;

namespace Signum.Persistence
{
    class ImmagineFissaPersister : IPersister<ImmagineFissa>
    {
        public ImmagineFissa Retrieve(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Save(ImmagineFissa element)
        {
            Modello modello = Documento.getInstance().ModelloRiferimento;

            using(BinaryWriter bw = new BinaryWriter(new FileStream(Documento.LIBRARY_PATH + element.Nome + ".elem", FileMode.Create), Encoding.UTF8))
            {
                bool isTestuale = element.InformazioneAssociata is InformazioneTestuale;
                bw.Write(modello.Size.Width);
                bw.Write(modello.Size.Height);
                bw.Write(PersisterFactory.IMMAGINE_FISSA);
                bw.Write(isTestuale);
                bw.Write((short)1);
                bw.Write(element.Frame.ToByteArray());
                if (isTestuale) bw.Write(element.InformazioneAssociata.Accept(new ValutatoreInformazione()));
            }
        }
    }
}
