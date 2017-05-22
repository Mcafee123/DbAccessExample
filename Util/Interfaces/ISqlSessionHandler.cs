using System;
using System.Data;

namespace Util.Interfaces
{
    public interface ISqlSessionHandler
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        ISqlSession CreateSqlSession();
        TResult RepoQuery<TResult>(Func<TResult> writeAction);
        int Execute(ICommand command);
        TResult Query<TResult>(IQuery<TResult> query);
    }
}