using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Persistence
{
    public static class PersisterFactory
    {
        public readonly static byte INFO_TESTO = Convert.ToByte(PersisterTypes.INFO_TESTO);
        public readonly static byte INFO_DATA_ORA = Convert.ToByte(PersisterTypes.INFO_DATA_ORA);
        public readonly static byte IMMAGINE_FISSA = Convert.ToByte(PersisterTypes.IMMAGINE_FISSA);
        public readonly static byte ANIMAZIONE = Convert.ToByte(PersisterTypes.ANIMAZIONE);
        public readonly static byte SEQUENZA = Convert.ToByte(PersisterTypes.SEQUENZA);
        public readonly static byte PROGRAMMAZIONE_GIORNALIERA = Convert.ToByte(PersisterTypes.PROGRAMMAZIONE_GIORNALIERA);
        public readonly static byte PROGRAMMAZIONE_SETTIMANALE = Convert.ToByte(PersisterTypes.PROGRAMMAZIONE_SETTIMANALE);

        private static IPersister[] _persisters;

        static PersisterFactory()
        {
            _persisters = new IPersister[Enum.GetNames(typeof(PersisterTypes)).Length];
            _persisters[INFO_TESTO] = new InformazioneTestualePersister();
            _persisters[INFO_DATA_ORA] = new InformazioneDataOraPersister();
            _persisters[IMMAGINE_FISSA] = new ImmagineFissaPersister();
            _persisters[ANIMAZIONE] = new AnimazionePersister();
            _persisters[SEQUENZA] = new SequenzaPersister();
            _persisters[PROGRAMMAZIONE_GIORNALIERA] = new SequenzaPersister();
            _persisters[PROGRAMMAZIONE_SETTIMANALE] = new SequenzaPersister();
        }

        #region legacy_support

        public static IPersister GetPersister(PersisterTypes type)
        {
            return GetPersister(Convert.ToByte(type));
        }
        public static IPersister GetPersister(byte type)
        {
            return _persisters.Length <= type ? null : _persisters[type];
        }

        #endregion

        public static IPersister GetPersister(Type type)
        {
            return (from persister in _persisters
                    where ((TypeAttribute)persister.GetType().GetCustomAttributes(false)[0]).Type == type
                    select persister).FirstOrDefault();
        }
        public static IPersister GetPersister(string type)
        {
            return (from persister in _persisters
                    where ((TypeAttribute)persister.GetType().GetCustomAttributes(false)[0]).Type.ToString() == type
                    select persister).FirstOrDefault();
        }
    }
}
