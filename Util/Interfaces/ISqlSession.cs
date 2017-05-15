using System;
using System.Data;

namespace Util.Interfaces
{
    public interface ISqlSession : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
        IDbConnection Connection { get; }
    }
}