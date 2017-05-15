using System;
using System.Data;

namespace Util.Interfaces
{
    public interface ISqlSessionHandler
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        ISqlSession CreateSqlSession();
        TResult Write<TResult>(Func<ISqlSessionHandler, TResult> writeAction);
        void Write(Action<ISqlSessionHandler> writeAction);
        TResult Read<TResult>(Func<ISqlSessionHandler, TResult> readAction);
    }
}