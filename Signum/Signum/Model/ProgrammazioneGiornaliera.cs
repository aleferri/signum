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
        public static readonly Sequenza SEQUENZA_DUMMY = new Sequenza();

        public static readonly int QUARTERS_IN_DAY = 4 * 24;
        public static readonly int QUARTER_DURATION = 15 * 60;
        public static readonly int SECONDS_IN_DAY = 60 * 60 * 24;

        private readonly Sequenza[] _sequenze;
        private string _nome;
        private IList<Sequenza> _sequenzeSingole;
        private bool validCache;

        public IEnumerable<Sequenza> Sequenze
        {
            get
            {
                if (validCache) return _sequenzeSingole;
                _sequenzeSingole = new List<Sequenza>();
                Sequenza old = null;
                foreach(Sequenza s in _sequenze)
                {
                    if(null != s && old != s && SEQUENZA_DUMMY != s)
                    {
                        old = s;
                        _sequenzeSingole.Add(s);
                    }
                }
                validCache = true;
                return _sequenzeSingole;

            }
        }
        public string Nome
        {
            get => _nome;
            set => _nome = value ?? String.Format("P.Girnaliera_{0}_{1}", DateTime.Now.ToShortDateString().Replace("/", "-"), DateTime.Now.ToShortTimeString().Replace(":", ""));
        }
        public IEnumerable<int> EmptySlots
        {
            get
            {
                IList<int> result = new List<int>();
                for(int i = 0; i < _sequenze.Length; i++)
                {
                    if (_sequenze[i] == SEQUENZA_DUMMY) result.Add(i);
                }
                return result;
            }
        }
       
        public Sequenza this[uint index] => _sequenze[index];
        public Sequenza this[int index] => _sequenze[index];

        public ProgrammazioneGiornaliera()
        {
            _sequenze = new Sequenza[QUARTERS_IN_DAY];
            for (int i = 0; i < _sequenze.Length; i++)
            {
                _sequenze[i] = SEQUENZA_DUMMY;
            }
            validCache = false;
        }

        private bool AggiungiSequenza(Sequenza s)
        {
            int required = s.Count;
            uint start = 0;
            int count = 0;
            bool accepted = false;
            for (uint i = 0; i < _sequenze.Length; i++)
            {
                if (SEQUENZA_DUMMY == _sequenze[i])
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
                    _sequenze[i] = s;
                }
            }
            return accepted;
        }
        public int Count()
        {
            return _sequenze.Count();
        }
        public int nDummy()
        {
            int res = 0;
            foreach(Sequenza sq in _sequenze)
            {
                if (sq == SEQUENZA_DUMMY) res++;
            }
            return res;
        }
        public void Remove(Sequenza s)
        {
            for (int i = 0; i < _sequenze.Length; i++)
            {
                if (_sequenze[i] == s)
                {
                    _sequenze[i] = SEQUENZA_DUMMY;
                }
            }
            validCache = false;
        }
        public bool InserisciSequenza(Sequenza s, FasciaOraria f)
        {
            if (SEQUENZA_DUMMY != _sequenze[f.StartQuarter])
            {
                return false;
            }
            bool accepted = true;
            for (uint i = f.StartQuarter; i < f.EndQuarter; i++)
            {
                accepted &= SEQUENZA_DUMMY == _sequenze[i];
            }
            if (accepted)
            {
                for (uint i = f.StartQuarter; i < f.EndQuarter; i++)
                {
                    _sequenze[i] = s;
                }
            }
            validCache = false;
            return accepted;
        }
        public void UpdateFasciaOraria(Sequenza s, FasciaOraria f)
        {
            Remove(s);
            InserisciSequenza(s, f);
        }
        public FasciaOraria GetFasciaOrariaOf(Sequenza s)
        {
            int sQuarter = -1, eQuarter = -1;
            for(int i = 0; i < _sequenze.Length; i++)
            {
                if(_sequenze[i] == s && -1 == sQuarter) sQuarter = i;
                if (_sequenze[i] == s && (-1 == eQuarter || -1 != sQuarter)) eQuarter = i + 1;
                if (-1 != sQuarter && -1 != eQuarter && _sequenze[i] != s) break;
            }

            return new FasciaOraria((uint)sQuarter, (uint)eQuarter);
        }
        public ProgrammazioneGiornaliera Copy()
        {
            ProgrammazioneGiornaliera p = new ProgrammazioneGiornaliera();
            foreach(Sequenza s in _sequenze)
            {
                p.AggiungiSequenza(s);
            }
            p.Nome = Nome;
            return p;
        }
        object ICopiable.Copy()
        {
            return Copy();
        }
        public override string ToString()
        {
            return _nome;
        }
    }
}
