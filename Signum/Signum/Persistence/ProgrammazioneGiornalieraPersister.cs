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
    [TypeAttribute(typeof(ProgrammazioneGiornaliera))]
    class ProgrammazioneGiornalieraPersister : IPersister<ProgrammazioneGiornaliera>
    {
        public ProgrammazioneGiornaliera Retrieve(BinaryReader br)
        {
            // Programmazione Giornaliera
            string nome = br.ReadString();
            ProgrammazioneGiornaliera result = new ProgrammazioneGiornaliera();
            result.Nome = nome;

            // Modello
            Modello modello = Documento.getInstance().ModelloRiferimento;
            int width = br.ReadInt32();
            int height = br.ReadInt32();
            if (width != modello.Size.Width || height != modello.Size.Height) return null;

            // Sequenze
            SequenzaPersister persister = new SequenzaPersister();
            Sequenza seq;
            FasciaOraria fo;
            string type;
            uint startQuarter, endQuarter;
            int count = br.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                type = br.ReadString();
                seq = persister.Retrieve(br);
                startQuarter = br.ReadUInt32();
                endQuarter = br.ReadUInt32();
                fo = new FasciaOraria(startQuarter, endQuarter);
                result.InserisciSequenza(seq, fo);
            }

            // Out
            return result;
        }

        public void Save(ProgrammazioneGiornaliera elem, BinaryWriter bw)
        {
            // Programmazione Giornaliera
            bw.Write(elem.GetType().ToString());
            bw.Write(elem.Nome);

            // Modello di riferimento
            Modello modello = Documento.getInstance().ModelloRiferimento;
            bw.Write(modello.Size.Width);
            bw.Write(modello.Size.Height);

            // Sequenze
            SequenzaPersister persister = new SequenzaPersister();
            FasciaOraria fo;
            Sequenza sq;
            bw.Write(elem.Count()-elem.nDummy());
            for (int i = 0; i < elem.Count(); i++)
            {
                sq = elem[i];
                if (sq == ProgrammazioneGiornaliera.SEQUENZA_DUMMY) continue;
                persister.Save(sq, bw);
                fo = elem.GetFasciaOrariaOf(sq);
                bw.Write(fo.StartQuarter);
                bw.Write(fo.EndQuarter);
            }
        }

        void IPersister.Save(object elem, BinaryWriter bw)
        {
            if (!(elem is ProgrammazioneGiornaliera)) throw new ArgumentException();
            Save((ProgrammazioneGiornaliera)elem, bw);
        }

        object IPersister.Retrieve(BinaryReader br)
        {
            return Retrieve(br);
        }
    }
}
