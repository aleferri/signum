using Signum.Common;
using System;

namespace Signum.Model
{
    public interface IInformazione : ICopiable<IInformazione>
    {
        T Accept<T>(IValutatoreInformazione<T> valutatore);

        IInformazione Copy();
    }
}
