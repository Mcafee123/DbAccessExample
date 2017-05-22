using Util.Interfaces;

namespace CommandQueryExample.Daten.Interfaces
{
    public interface IQuery<T>
    {
        T Execute(ISqlSessionHandler sessionHandler);
    }
}