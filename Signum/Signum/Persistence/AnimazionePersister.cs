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
            throw new NotImplementedException();
        }

        public void Save(Animazione elem, BinaryWriter bw)
        {
            throw new NotImplementedException();
        }

        void IPersister.Save(object elem, BinaryWriter bw)
        {
            throw new NotImplementedException();
        }

        object IPersister.Retrive(BinaryReader br)
        {
            throw new NotImplementedException();
        }
    }
}
