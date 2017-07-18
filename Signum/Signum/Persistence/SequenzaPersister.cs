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
    [TypeAttribute(typeof(Sequenza))]
    class SequenzaPersister : IPersister<Sequenza>
    {
        public Sequenza Retrieve(BinaryReader br)
        {
            // Sequenza
            string nome = br.ReadString();
            Sequenza result = new Sequenza();
            result.Nome = nome;

            // Modello
            Modello modello = Documento.getInstance().ModelloRiferimento;
            int width = br.ReadInt32();
            int height = br.ReadInt32();
            if (width != modello.Size.Width || height != modello.Size.Height) return null;

            // Elementi
            int nElementi = br.ReadInt32();
            uint durata;
            string type;
            IPersister persister;
            for (int i = 0; i < nElementi; i++)
            {
                durata = br.ReadUInt32();
                type = br.ReadString();
                persister = PersisterFactory.GetPersister(type);
                result.AggiungiElemento((Elemento)persister.Retrieve(br), durata);
            }

            // Out
            return result;
        }

        public void Save(Sequenza elem, BinaryWriter bw)
        {
            // Sequenza
            bw.Write(elem.GetType().ToString());
            bw.Write(elem.Nome);

            // Modello di riferimento
            Modello modello = Documento.getInstance().ModelloRiferimento;
            bw.Write(modello.Size.Width);
            bw.Write(modello.Size.Height);

            // Elementi
            bw.Write(elem.Count);
            Elemento value;
            IPersister persister;
            for(int i=0; i<elem.Count; i++)
            {
                value = elem[i];
                bw.Write(elem.GetDurataOf(value));
                persister = PersisterFactory.GetPersister(value.GetType());
                persister.Save(value, bw);
            }

        }

        void IPersister.Save(object elem, BinaryWriter bw)
        {
            if (!(elem is Sequenza)) throw new ArgumentException();
            Save((Sequenza)elem, bw);
        }

        object IPersister.Retrieve(BinaryReader br)
        {
            return Retrieve(br);
        }
    }
}
