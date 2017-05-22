using System.Data;

namespace Util
{
    public interface IQuery<T>
    {
        T Execute(IDbConnection connection, IDbTransaction transaction);
    }
}