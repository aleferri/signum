namespace Signum.Model
{
    public interface IInformazione
    {
         T Accept<T>(IValutatoreInformazione<T> valutatore);
    }
}
