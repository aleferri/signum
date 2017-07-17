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

        public IEnumerable<MementoWrapper<ImmagineFissa>> ImmaginiFisse =>
            from ImmagineFissa imm
            in _immaginiFisse
            select new MementoWrapper<ImmagineFissa>((ImmagineFissa)imm.Copy(), _immaginiFisse.IndexOf(imm));
        public IEnumerable<MementoWrapper<Animazione>> Animazioni =>
            from Animazione a
            in _animazioni
            select new MementoWrapper<Animazione>((Animazione)a.Copy(), _animazioni.IndexOf(a));
        public IEnumerable<MementoWrapper<Sequenza>> Sequenze =>
            from Sequenza s
            in _sequenze
            select new MementoWrapper<Sequenza>(s.Copy(), _sequenze.IndexOf(s));
        public IEnumerable<MementoWrapper<ProgrammazioneGiornaliera>> ProgrGiornaliere =>
            from ProgrammazioneGiornaliera p
            in _progrGiornaliere
            select new MementoWrapper<ProgrammazioneGiornaliera>(p.Copy(), _progrGiornaliere.IndexOf(p));

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
                object result = persister.Retrieve(br);

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
                    InsideAggiungiElemento(new MementoWrapper<Elemento>((Elemento)result));
                }
            }
        }
        private void InsideAggiungiElemento(MementoWrapper<Elemento> elemento)
        {
            IList lista = null;
            if (null != elemento.Memento as ImmagineFissa)  lista = _immaginiFisse;
            else if (null != elemento.Memento as Animazione) lista = _animazioni;         
            if (elemento.ID >= 0 && elemento.ID < lista.Count)
            {
                lista?.RemoveAt(elemento.ID);
                lista?.Insert(elemento.ID, elemento.Memento);
            }
            else lista?.Add(elemento.Memento);
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

        public void AggiungiElemento(MementoWrapper<Elemento> elemento)
        {
            string nomeFile = _base + elemento.Memento.Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".elem";
            if (elemento.ID < 0 && !Overwrite(nomeFile)) return;
            InsideAggiungiElemento(elemento);
            using (BinaryWriter bw = new BinaryWriter(new FileStream(nomeFile, FileMode.Create)))
            {
                PersisterFactory.GetPersister(elemento.Memento.GetType()).Save(elemento.Memento, bw);
            }
        }
        public void AggiungiProgrGiornaliera(MementoWrapper<ProgrammazioneGiornaliera> progrGiornaliera)
        {
            throw new NotImplementedException();
            LibreriaChange?.Invoke(this, EventArgs.Empty);
        }
        public void AggiungiSequenza(MementoWrapper<Sequenza> sequenza)
        {
            string nomeFile = _base + sequenza.Memento.Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".seq";

            if (sequenza.ID >= 0 && sequenza.ID < _sequenze.Count)
            {
                _sequenze.RemoveAt(sequenza.ID);
                _sequenze.Insert(sequenza.ID, sequenza.Memento);
            }
            else
            {
                if (!Overwrite(nomeFile)) return;
                _sequenze.Add(sequenza.Memento);
            }

            using (BinaryWriter bw = new BinaryWriter(new FileStream(nomeFile, FileMode.Create)))
            {
                PersisterFactory.GetPersister(PersisterFactory.SEQUENZA).Save(sequenza.Memento, bw);
            }

            LibreriaChange?.Invoke(this, EventArgs.Empty);

        }
    }
}
