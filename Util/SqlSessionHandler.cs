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

        public TResult Write<TResult>(Func<TResult> writeAction)
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
            TResult result;
            try
            {
                result = writeAction();
            }
            finally
            {
                if (!hasTransaction)
                {
                    _session.Commit();
                }
                if (!hasSession)
                {
                    _session.Dispose();
                    _session = null;
                }
            }
            return result;
        }

        public void Write(Action writeAction)
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
                writeAction();
            }
            finally
            {
                if (!hasTransaction)
                {
                    _session.Commit();
                }
                if (!hasSession)
                {
                    _session.Dispose();
                    _session = null;
                }
            }
        }

        public TResult Read<TResult>(Func<TResult> readAction)
        {
            var hasSession = HasSession();
            if (!hasSession)
            {
                _session = CreateSqlSession();
            }
            TResult result;
            try
            {
                result = readAction();
            }
            finally
            {
                if (!hasSession)
                {
                    _session.Dispose();
                    _session = null;
                }
            }
            return result;
        }

        private bool HasSession()
        {
            return _session != null;
        }
    }
}