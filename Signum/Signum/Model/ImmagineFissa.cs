using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    class ImmagineFissa : IElemento
    {
        private Frame _frame;
        private IInformazione _informazione;

        public Frame Frame => _frame;
        public IInformazione InfomazioneAssociata
        {
            get => _informazione;
            set => _informazione = value;
        }
    }
}
