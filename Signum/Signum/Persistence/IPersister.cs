﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Persistence
{
    [DefaultValueAttribute(null)]
    public interface IPersister
    {
        void Save(Object elem, BinaryWriter bw);
        Object Retrieve(BinaryReader br);
    }
    public interface IPersister<T> : IPersister
    {
        void Save(T elem, BinaryWriter bw);
        new T Retrieve(BinaryReader br);
    }
}
