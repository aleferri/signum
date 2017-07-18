using Signum.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Persistence
{
    [TypeAttribute(typeof(InformazioneTestuale))]
    internal class InformazioneTestualePersister : IPersister<InformazioneTestuale>
    {
        public InformazioneTestuale Retrieve(BinaryReader br)
        {
            return new InformazioneTestuale(br.ReadString());
        }

        public void Save(InformazioneTestuale elem, BinaryWriter bw)
        {
            bw.Write(elem.GetType().ToString());
            bw.Write(elem.Valore);
        }

        void IPersister.Save(object elem, BinaryWriter bw)
        {
            if (!(elem is InformazioneTestuale)) throw new ArgumentException();
            this.Save((InformazioneTestuale) elem, bw);
        }

        object IPersister.Retrieve(BinaryReader br)
        {
            return this.Retrieve(br);
        }
    }
}
