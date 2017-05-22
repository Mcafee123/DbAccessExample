using System;
using System.Data;
using Util.Interfaces;

namespace Util
{
    public class SqlSessionHandler : ISqlSessionHandler
    {
        private readonly ISqlSessionFactory _sqlSessionFactory;
        private ISqlSession _session;

        public SqlSessionHandler(ISqlSessionFactory sqlSessionFactory)
        {
            _sqlSessionFactory = sqlSessionFactory;
        }

        public ISqlSession CreateSqlSession()
        {
            _session = _sqlSessionFactory.CreateSqlSession();
            return _session;
        }

        public IDbConnection Connection => _session.Connection;
        public IDbTransaction Transaction => _session.SqlTransaction?.Transaction;

        public TResult RepoQuery<TResult>(Func<TResult> writeAction)
        {
            var sessionHandeledOutside = HasSession();
            if (!sessionHandeledOutside)
            {
                _session = CreateSqlSession();
            }
            var transactionHandeledOutside = _session.HasTransaction;
            if (!transactionHandeledOutside)
            {
                _session.Begin();
            }
            try
            {
                var result = writeAction();
                if (!transactionHandeledOutside)
                {
                    _session.Commit();
                }
                return result;
            }
            catch
            {
                if (!transactionHandeledOutside)
                {
                    _session.SqlTransaction.Rollback();
                }
                throw;
            }
            finally
            {
                if (!sessionHandeledOutside)
                {
                    _session.Dispose();
                    _session = null;
                }
            }
        }

        public TResult Query<TResult>(IQuery<TResult> query)
        {
            var hasSession = HasSession();
            if (!hasSession)
            {
                _session = CreateSqlSession();
            }
            var hasTransaction = _session.HasTransaction;
            if (!hasTransaction)
            {
                _session.Begin();
            }
            try
            {
                var result = query.Execute(Connection, Transaction);
                if (!hasTransaction)
                {
                    _session.Commit();
                }
                return result;
            }
            catch
            {
                if (!hasTransaction)
                {
                    _session.SqlTransaction.Rollback();
                }
                throw;
            }
            finally
            {
                if (!hasSession)
                {
                    _session.Dispose();
                    _session = null;
                }
            }
        }

        public int Execute(ICommand command)
        {
            return Query(command);
        }

        private bool HasSession()
        {
            return _session != null && _session.Connection != null;
        }
    }
}