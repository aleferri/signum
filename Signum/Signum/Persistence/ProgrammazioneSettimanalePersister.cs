using Signum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ModelManaging;

namespace Signum.Persistence
{
    [TypeAttribute(typeof(ProgrammazioneSettimanale))]
    class ProgrammazioneSettimanalePersister : IPersister<ProgrammazioneSettimanale>
    {
        public ProgrammazioneSettimanale Retrieve(BinaryReader br)
        {
            // Programmazione Settimanale
            ProgrammazioneSettimanale result = new ProgrammazioneSettimanale();

            // Modello
            Modello modello = Documento.getInstance().ModelloRiferimento;
            int width = br.ReadInt32();
            int height = br.ReadInt32();
            if (width != modello.Size.Width || height != modello.Size.Height) return null;

            // Programmazioni Giornaliere
            ProgrammazioneGiornalieraPersister persister = new ProgrammazioneGiornalieraPersister();
            ProgrammazioneGiornaliera pg;
            string type;
            int dow = br.ReadInt32();
            while (dow > 0)
            {
                type = br.ReadString();
                pg = persister.Retrieve(br);
                result[(DayOfWeek)dow] = pg;
                dow = br.ReadInt32();
            }
            // Out
            return result;
        }

        public void Save(ProgrammazioneSettimanale elem, BinaryWriter bw)
        {
            // Programmazione Settimanale
            bw.Write(elem.GetType().ToString());

            // Modello di riferimento
            Modello modello = Documento.getInstance().ModelloRiferimento;
            bw.Write(modello.Size.Width);
            bw.Write(modello.Size.Height);

            // Programmazioni Giornaliere
            ProgrammazioneGiornalieraPersister persister = new ProgrammazioneGiornalieraPersister();
            ProgrammazioneGiornaliera pg;
            foreach(DayOfWeek dow in Enum.GetValues(typeof(DayOfWeek)))
            {
                pg = elem[dow];
                if (pg == null) continue;
                bw.Write((int)dow);
                persister.Save(elem[dow], bw);
            }
            bw.Write(-1);
        }

        void IPersister.Save(object elem, BinaryWriter bw)
        {
            throw new NotImplementedException();
        }

        object IPersister.Retrieve(BinaryReader br)
        {
            throw new NotImplementedException();
        }
    }
}
