﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public class InformazioneDataOra : IInformazione
    {
        public T Accept<T>(IValutatoreInformazione<T> valutatore)
        {
            return valutatore.Visit(this);
        }
    }
}
