using System;
using System.Data;

namespace Util.Interfaces
{
    public interface ISqlSession : IDisposable
    {
        IDbConnection Connection { get; }
        bool HasTransaction { get; }
        ISqlTransaction SqlTransaction { get; }
        void Begin();
        void Commit();
    }
}