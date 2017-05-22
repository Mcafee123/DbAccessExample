using System;
using System.Data;

namespace Util.Interfaces
{
    public interface ISqlSessionHandler
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        ISqlSession CreateSqlSession();
        TResult Write<TResult>(Func<TResult> writeAction);
        void Write(Action writeAction);
        TResult Read<TResult>(Func<TResult> readAction);
    }
}