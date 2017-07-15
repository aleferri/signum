using Signum.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Model
{
    class Libreria : ILibreria
    {
        public event EventHandler LibreriaChange;

        private readonly List<Elemento> _immaginiFisse;
        private readonly List<Elemento> _animazioni;
        private readonly List<Sequenza> _sequenze;
        private readonly List<ProgrammazioneGiornaliera> _progrGiornaliere;

        private string _base;

        public IEnumerable<ModelToPersistenceWrapper<ImmagineFissa>> ImmaginiFisse =>
            from ImmagineFissa imm
            in _immaginiFisse
            select new ModelToPersistenceWrapper<ImmagineFissa>((ImmagineFissa)imm.Copy(), _immaginiFisse.IndexOf(imm));
        public IEnumerable<ModelToPersistenceWrapper<Animazione>> Animazioni =>
            from Animazione a
            in _animazioni
            select new ModelToPersistenceWrapper<Animazione>((Animazione)a.Copy(), _animazioni.IndexOf(a));
        public IEnumerable<ModelToPersistenceWrapper<Sequenza>> Sequenze =>
            from Sequenza s
            in _sequenze
            select new ModelToPersistenceWrapper<Sequenza>(s.Copy(), _sequenze.IndexOf(s));
        public IEnumerable<ModelToPersistenceWrapper<ProgrammazioneGiornaliera>> ProgrGiornaliere =>
            from ProgrammazioneGiornaliera p
            in _progrGiornaliere
            select new ModelToPersistenceWrapper<ProgrammazioneGiornaliera>(p.Copy(), _progrGiornaliere.IndexOf(p));

        public Libreria(string baseRoot)
        {
            _immaginiFisse = new List<Elemento>();
            _animazioni = new List<Elemento>();
            _sequenze = new List<Sequenza>();
            _progrGiornaliere = new List<ProgrammazioneGiornaliera>();
            _base = baseRoot;
            ReadFiles();
        }

        private void ReadFiles()
        {
            if (!Directory.Exists(_base)) return;
            try
            {
                string[] fileNames = Directory.GetFiles(_base);
                foreach (string s in fileNames)
                {
                    ReadSingle(s);
                }
            }
            catch
            {
                Console.WriteLine("Errore lettura libreria. Inserire gestione.");
            }
        }
        private void ReadSingle(string fileName)
        {
            using (BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
            {
                IPersister persister = PersisterFactory.GetPersister(br.ReadString());
                object result = persister.Retrive(br);

                if (null != result as Sequenza)
                {
                    _sequenze.Add((Sequenza)result);
                }
                else if (null != result as ProgrammazioneGiornaliera)
                {
                    _progrGiornaliere.Add((ProgrammazioneGiornaliera)result);
                }
                else
                {
                    InsideAggiungiElemento(new ModelToPersistenceWrapper<Elemento>((Elemento)result));
                }
            }
        }
        private void InsideAggiungiElemento(ModelToPersistenceWrapper<Elemento> elemento)
        {
            IList lista = null;
            if (null != elemento.ModelElement as ImmagineFissa)  lista = _immaginiFisse;
            else if (null != elemento.ModelElement as Animazione) lista = _animazioni;         
            if (elemento.ID >= 0 && elemento.ID < lista.Count)
            {
                lista?.RemoveAt(elemento.ID);
                lista?.Insert(elemento.ID, elemento.ModelElement);
            }
            else lista?.Add(elemento.ModelElement);
            LibreriaChange?.Invoke(this, EventArgs.Empty);
        }
        private bool Overwrite(string fileName)
        {
            if (!File.Exists(fileName)) return true;
            DialogResult result = MessageBox.Show(null, 
                "Un elemento per il modello corrente con questo nome esiste già. Vuoi sostituirlo?",
                "Sovrascrittura",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            return DialogResult.Yes == result;
        }

        public void AggiungiElemento(ModelToPersistenceWrapper<Elemento> elemento)
        {
            string nomeFile = _base + elemento.ModelElement.Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".elem";
            if (elemento.ID < 0 && !Overwrite(nomeFile)) return;
            InsideAggiungiElemento(elemento);
            using (BinaryWriter bw = new BinaryWriter(new FileStream(nomeFile, FileMode.Create)))
            {
                PersisterFactory.GetPersister(elemento.ModelElement.GetType()).Save(elemento.ModelElement, bw);
            }
        }
        public void AggiungiProgrGiornaliera(ModelToPersistenceWrapper<ProgrammazioneGiornaliera> progrGiornaliera)
        {
            throw new NotImplementedException();
            LibreriaChange?.Invoke(this, EventArgs.Empty);
        }
        public void AggiungiSequenza(ModelToPersistenceWrapper<Sequenza> sequenza)
        {
            string nomeFile = _base + sequenza.ModelElement.Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".seq";

            if (sequenza.ID >= 0 && sequenza.ID < _sequenze.Count)
            {
                int index = _sequenze.IndexOf(sequenza.ModelElement);
                _sequenze.Remove(sequenza.ModelElement);
                _sequenze.Insert(index, sequenza.ModelElement);
            }
            else
            {
                if (!Overwrite(nomeFile)) return;
                _sequenze.Add(sequenza.ModelElement);
            }

            using (BinaryWriter bw = new BinaryWriter(new FileStream(nomeFile, FileMode.Create)))
            {
                PersisterFactory.GetPersister(PersisterFactory.SEQUENZA).Save(sequenza.ModelElement, bw);
            }

            LibreriaChange?.Invoke(this, EventArgs.Empty);

        }
    }
}
