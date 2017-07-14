using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{

    public class ProgrammazioneGiornaliera
    {

        public static readonly uint SECONDS_IN_DAY = 60 * 60 * 24;

        private readonly IList<Sequenza> _sequences;
        private readonly IList<Sequenza> _dummies;
        private string _nome;

        public IEnumerable<Sequenza> Sequenze => _sequences;
        public string Nome
        {
            get => _nome;
            set => _nome = value ?? String.Format("P.Girnaliera_{0}_{1}", DateTime.Now.ToShortDateString().Replace("/", "-"), DateTime.Now.ToShortTimeString().Replace(":", ""));
        }

        public ProgrammazioneGiornaliera()
        {
            _sequences = new List<Sequenza>();
            _dummies = new List<Sequenza>();
            Sequenza dummy = new Sequenza();
            dummy.AggiungiElemento(ElementoDummy.DUMMY, Sequenza.MAX_DURATION);
            _dummies.Add(dummy);
            _sequences.Add(dummy);
        }

        private int FindNearDummy(int index, out Sequenza dummy)
        {
            if (index > 0)
            {
                if (_dummies.Contains(_sequences[index - 1]))
                {
                    dummy = _sequences[index - 1];
                    return index - 1;
                }
            }
            if (index < _sequences.Count - 1)
            {
                if (_dummies.Contains(_sequences[index + 1]))
                {
                    dummy = _sequences[index + 1];
                    return index + 1;
                }
            }
            dummy = null;
            return -1;
        }

        private int FindDummy(uint durata, out Sequenza dummy)
        {
            IEnumerable<Sequenza> seqs = from Sequenza s in _sequences
                                         orderby Math.Abs(s.Durata - durata)
                                         select s;
            dummy = seqs.Count() > 0 ? seqs.First() : null;
            if (dummy == null)
            {
                return -1;
            }
            return _sequences.IndexOf(dummy);
        }

        private void MergeDummies(int startIndex)
        {
            if (startIndex < _sequences.Count)
            {
                return;
            }
            Sequenza a = _sequences[startIndex];
            Sequenza b = _sequences[startIndex + 1];
            if (_dummies.Contains(a) && _dummies.Contains(b))
            {
                Sequenza dummy = new Sequenza();
                dummy.AggiungiElemento(ElementoDummy.DUMMY, a.Durata + b.Durata);
                _dummies.Remove(a);
                _dummies.Remove(b);
                _sequences[startIndex] = dummy;
                _sequences.Remove(b);
            }
        }

        public void Remove(Sequenza s)
        {
            Sequenza dummy;
            int indexOf = FindNearDummy(_sequences.IndexOf(s), out dummy);
            _sequences.Remove(s);
            if (dummy != null)
            {
                dummy.AggiungiElemento(ElementoDummy.DUMMY, s.Durata);
                MergeDummies(indexOf);
            }
            else
            {
                Sequenza dummyReplace = new Sequenza();
                dummyReplace.AggiungiElemento(ElementoDummy.DUMMY, s.Durata);
            }
        }

        public bool AggiungiSequenza(Sequenza s)
        {
            int indexOf = FindDummy(s.Durata, out Sequenza dummy);
            if (indexOf < 0)
            {
                throw new ArgumentException("Impossibile insere, nessuno spazio libero");
            }
            bool trimmed = _sequences[indexOf].Durata < s.Durata;
            uint fitDurata = trimmed
                    ? _sequences[indexOf].Durata
                    : s.Durata;
            uint durationLeft = _sequences[indexOf].Durata - fitDurata;
            _sequences.Remove(dummy);
            _dummies.Remove(dummy);
            if (durationLeft > 0)
            {
                Sequenza cDummy = new Sequenza();
                cDummy.AggiungiElemento(ElementoDummy.DUMMY, durationLeft);
                _dummies.Add(cDummy);
                _sequences.Insert(indexOf, cDummy);
            }
            _sequences.Insert(indexOf, s);
            return !trimmed;
        }

        public ProgrammazioneGiornaliera Copy()
        {
            ProgrammazioneGiornaliera p = new ProgrammazioneGiornaliera();
            foreach(Sequenza s in _sequences)
            {
                p.AggiungiSequenza(s);
            }
            return p;
        }
    }
}
