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
        public Sequenza Retrive(BinaryReader br)
        {
            // Modello
            Modello modello = Documento.getInstance().ModelloRiferimento;
            int width = br.ReadInt32();
            int height = br.ReadInt32();
            if (width != modello.Size.Width || height != modello.Size.Height) throw new FileLoadException("Modello non compatibile");

            // Sequenza
            if (br.ReadString() != typeof(Sequenza).GetType().ToString()) throw new FileLoadException("Tipo non compatibile");
            string nome = br.ReadString();
            Sequenza result = new Sequenza();
            result.Nome = nome;
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
                if (!(persister.GetType().GetCustomAttributes(false)[0] is Elemento)) throw new FileLoadException("Elemento non compatibile");
                result.AggiungiElemento((Elemento)persister.Retrive(br), durata);
            }

            // Out
            return result;
        }

        public void Save(Sequenza elem, BinaryWriter bw)
        {
            // Modello di riferimento
            Modello modello = Documento.getInstance().ModelloRiferimento;
            bw.Write(modello.Size.Width);
            bw.Write(modello.Size.Height);

            // Sequenza
            bw.Write(elem.GetType().ToString());
            bw.Write(elem.Nome);
            // Elementi
            bw.Write(elem.Count);
            KeyValuePair<Elemento, uint> value;
            IPersister persister;
            for(int i=0; i<elem.Count; i++)
            {
                value = elem[i];
                bw.Write(value.Value);
                bw.Write(value.Key.GetType().ToString());
                persister = PersisterFactory.GetPersister(value.Key.GetType());
                persister.Save(value.Key, bw);
            }

        }

        void IPersister.Save(object elem, BinaryWriter bw)
        {
            if (!(elem is Sequenza)) throw new ArgumentException();
            this.Save((Sequenza)elem, bw);
        }

        object IPersister.Retrive(BinaryReader br)
        {
            return this.Retrive(br);
        }
    }
}
