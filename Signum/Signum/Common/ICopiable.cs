
namespace Signum.Common
{
    /// <summary>
    /// Interfaccia per la deep copy di un oggetto
    /// </summary>
    public interface ICopiable
    {
        object Copy();
    }

    /// <summary>
    /// Interfaccia generica per la deep copy di un oggetto
    /// </summary>
    public interface ICopiable<T> : ICopiable
    {
        new T Copy();
    }
}
