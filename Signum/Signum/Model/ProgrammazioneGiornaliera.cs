using Signum.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{

    public class ProgrammazioneGiornaliera : ICopiable<ProgrammazioneGiornaliera>
    {

        public static readonly uint QUARTERS_IN_DAY = 4 * 24;
        public static readonly uint QUARTER_DURATION = 15 * 60;
        public static readonly uint SECONDS_IN_DAY = 60 * 60 * 24;

        private readonly Sequenza[] _sequences;
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
            _sequences = new Sequenza[96];
            _dummies = new List<Sequenza>();
            Sequenza dummy = new Sequenza();
            dummy.AggiungiElemento(ElementoDummy.DUMMY, Sequenza.MAX_DURATION);
            _dummies.Add(dummy);
            for (int i = 0; i < _sequences.Length; i++)
            {
                _sequences[i] = dummy;
            }
        }

        public void Remove(Sequenza s)
        {
            Sequenza dummy = null;
            for (int i = 0; i < _sequences.Length; i++)
            {
                if (_sequences[i] == s)
                {
                    if (dummy == null)
                    {
                        dummy = new Sequenza();
                        _dummies.Add(dummy);
                    }
                    dummy.AggiungiElemento(ElementoDummy.DUMMY, QUARTER_DURATION);
                    _sequences[i] = dummy;
                }
                else
                {
                    dummy = _dummies.Contains(_sequences[i]) ? _sequences[i] : null;
                }
            }
        }

        public bool AggiungiSequenza(Sequenza s)
        {
            int required = s.Count;
            uint start = 0;
            int count = 0;
            bool accepted = false;
            for (uint i = 0; i < _sequences.Length; i++)
            {
                if (_dummies.Contains(_sequences[i]))
                {
                    count++;
                    if (count == required)
                    {
                        accepted = true;
                        break;
                    }
                }
                else
                {
                    count = 0;
                    start = i + 1;
                }
            }
            if (accepted)
            {
                for (uint i = start; i < start + count; i++)
                {
                    _sequences[i] = s;
                }
            }
            return accepted;
        }

        public bool InserisciSequenza(Sequenza s, FasciaOraria f)
        {
            if (!_dummies.Contains(_sequences[f.StartQuarter]))
            {
                return false;
            }
            bool accepted = true;
            for (uint i = f.StartQuarter; i < f.EndQuarter + 1; i++)
            {
                accepted &= _dummies.Contains(_sequences[i]);
            }
            if (accepted)
            {
                for (uint i = f.StartQuarter; i < f.EndQuarter + 1; i++)
                {
                    _sequences[i] = s;
                }
            }
            return accepted;
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
