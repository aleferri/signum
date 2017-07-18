using Signum.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Persistence
{
    [TypeAttribute(typeof(InformazioneDataOra))]
    class InformazioneDataOraPersister : IPersister<InformazioneDataOra>
    {
        public InformazioneDataOra Retrieve(BinaryReader br)
        {
            return new InformazioneDataOra();
        }

        public void Save(InformazioneDataOra elem, BinaryWriter bw)
        {
            bw.Write(elem.GetType().ToString());
        }

        void IPersister.Save(object elem, BinaryWriter bw)
        {
            if (!(elem is InformazioneDataOra)) throw new ArgumentException();
            this.Save((InformazioneDataOra)elem, bw);
        }

        object IPersister.Retrieve(BinaryReader br)
        {
            return this.Retrieve(br);
        }
    }
}
