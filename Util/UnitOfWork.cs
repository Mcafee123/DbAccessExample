using System;
using System.Data;
using Util.Interfaces;

namespace Util
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly Guid _id;
        private IDbTransaction _transaction;

        internal UnitOfWork(IDbConnection connection)
        {
            _id = Guid.NewGuid();
            _connection = connection;
        }

        IDbTransaction IUnitOfWork.Transaction => _transaction;

        Guid IUnitOfWork.Id => _id;

        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;
        }
    }
}