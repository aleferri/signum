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

        public IEnumerable<PersisterMapper<ImmagineFissa>> ImmaginiFisse =>
            from ImmagineFissa imm
            in _immaginiFisse
            select new PersisterMapper<ImmagineFissa>((ImmagineFissa)imm.Copy(), _immaginiFisse.IndexOf(imm));
        public IEnumerable<PersisterMapper<Animazione>> Animazioni =>
            from Animazione a
            in _animazioni
            select new PersisterMapper<Animazione>((Animazione)a.Copy(), _animazioni.IndexOf(a));
        public IEnumerable<PersisterMapper<Sequenza>> Sequenze =>
            from Sequenza s
            in _sequenze
            select new PersisterMapper<Sequenza>(s.Copy(), _sequenze.IndexOf(s));
        public IEnumerable<PersisterMapper<ProgrammazioneGiornaliera>> ProgrGiornaliere =>
            from ProgrammazioneGiornaliera p
            in _progrGiornaliere
            select new PersisterMapper<ProgrammazioneGiornaliera>(p.Copy(), _progrGiornaliere.IndexOf(p));

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
                    InsideAggiungiElemento(new PersisterMapper<Elemento>((Elemento)result));
                }
            }
        }
        private void InsideAggiungiElemento(PersisterMapper<Elemento> elemento)
        {
            IList lista = null;
            if (null != elemento.Element as ImmagineFissa)  lista = _immaginiFisse;
            else if (null != elemento.Element as Animazione) lista = _animazioni;         
            if (elemento.ID >= 0 && elemento.ID < lista.Count)
            {
                lista?.RemoveAt(elemento.ID);
                lista?.Insert(elemento.ID, elemento.Element);
            }
            else lista?.Add(elemento.Element);
            LibreriaChange?.Invoke(this, EventArgs.Empty);
        }
        private bool Overwrite(string fileName)
        {
            if (!File.Exists(fileName)) return true;
            DialogResult result = MessageBox.Show(null, 
                "Un elemento compatibile con il modello corrente con questo nome esiste già. Vuoi sostituirlo?",
                "Sovrascrittura",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            return DialogResult.Yes == result;
        }

        public void AggiungiElemento(PersisterMapper<Elemento> elemento)
        {
            string nomeFile = _base + elemento.Element.Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".elem";
            if (elemento.ID < 0 && !Overwrite(nomeFile)) return;
            InsideAggiungiElemento(elemento);
            using (BinaryWriter bw = new BinaryWriter(new FileStream(nomeFile, FileMode.Create)))
            {
                PersisterFactory.GetPersister(elemento.Element.GetType()).Save(elemento.Element, bw);
            }
        }
        public void AggiungiProgrGiornaliera(PersisterMapper<ProgrammazioneGiornaliera> progrGiornaliera)
        {
            string nomeFile = _base + progrGiornaliera.Element.Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".prg";
            if(progrGiornaliera.ID >= 0 && progrGiornaliera.ID < _progrGiornaliere.Count)
            {
                _progrGiornaliere.RemoveAt(progrGiornaliera.ID);
                _progrGiornaliere.Insert(progrGiornaliera.ID, progrGiornaliera.Element);
            }
            else
            {
                if (!Overwrite(nomeFile)) return;
                _progrGiornaliere.Add(progrGiornaliera.Element);
            }

            using(BinaryWriter bw = new BinaryWriter(new FileStream(nomeFile, FileMode.Create)))
            {
                PersisterFactory.GetPersister(progrGiornaliera.Element.GetType()).Save(progrGiornaliera.Element, bw);
            }

            LibreriaChange?.Invoke(this, EventArgs.Empty);
        }
        public void AggiungiSequenza(PersisterMapper<Sequenza> sequenza)
        {
            string nomeFile = _base + sequenza.Element.Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".seq";

            if (sequenza.ID >= 0 && sequenza.ID < _sequenze.Count)
            {
                _sequenze.RemoveAt(sequenza.ID);
                _sequenze.Insert(sequenza.ID, sequenza.Element);
            }
            else
            {
                if (!Overwrite(nomeFile)) return;
                _sequenze.Add(sequenza.Element);
            }

            using (BinaryWriter bw = new BinaryWriter(new FileStream(nomeFile, FileMode.Create)))
            {
                PersisterFactory.GetPersister(PersisterFactory.SEQUENZA).Save(sequenza.Element, bw);
            }

            LibreriaChange?.Invoke(this, EventArgs.Empty);
        }

        public void EliminaImmagineFissa(int index)
        {
            string nomeFile = _base + _immaginiFisse[index].Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".elem";
            try
            {
                File.Delete(nomeFile);
            }
            catch
            {
            }
            _immaginiFisse.RemoveAt(index);
            LibreriaChange?.Invoke(this, EventArgs.Empty);
        }

        public void EliminaAnimazione(int index)
        {
            string nomeFile = _base + _animazioni[index].Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".elem";
            try
            {
                File.Delete(nomeFile);
            }
            catch
            {
            }
            _animazioni.RemoveAt(index);
            LibreriaChange?.Invoke(this, EventArgs.Empty);
        }

        public void EliminaSequenza(int index)
        {
            string nomeFile = _base + _sequenze[index].Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".seq";
            try
            {
                File.Delete(nomeFile);
            }
            catch
            {
            }
            _sequenze.RemoveAt(index);
            LibreriaChange?.Invoke(this, EventArgs.Empty);
        }

        public void EliminaProgrGiornaliera(int index)
        {
            string nomeFile = _base + _progrGiornaliere[index].Nome + "_" + Documento.getInstance().ModelloRiferimento.ToString() + ".prg";
            try
            {
                File.Delete(nomeFile);
            }
            catch
            {
            }
            _progrGiornaliere.RemoveAt(index);
            LibreriaChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
