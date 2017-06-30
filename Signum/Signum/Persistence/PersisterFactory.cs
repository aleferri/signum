using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Persistence
{
    public class PersisterFactory
    {
        public readonly static byte IMMAGINE_FISSA = Convert.ToByte(PersisterTypes.IMMAGINE_FISSA);

        private IPersister[] _persisters;

        public PersisterFactory()
        {
            _persisters = new IPersister[Enum.GetNames(typeof(PersisterTypes)).Length];
            _persisters[IMMAGINE_FISSA] = new ImmagineFissaPersister();
        }

        public IPersister GetPersister(PersisterTypes type)
        {
            return GetPersister(Convert.ToByte(type));
        }
        public IPersister GetPersister(byte type)
        {
            return _persisters.Length <= type ? null : _persisters[type];
        }
    }
}
