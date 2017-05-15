using System;
using System.Data;
using Util.Interfaces;

namespace Util
{
    internal sealed class SqlTransaction : ISqlTransaction
    {
        private readonly Guid _id;
        private readonly IDbConnection _connection;
        private bool _disposed;
        private IDbTransaction _transaction;

        internal SqlTransaction(IDbConnection connection)
        {
            _id = Guid.NewGuid();
            _connection = connection;
        }

        internal bool HasTransaction => _transaction != null;

        IDbTransaction ISqlTransaction.Transaction => _transaction;

        Guid ISqlTransaction.Id => _id;

        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Transaktion disposen, falls Commit() nicht aufgerufen wurde
                    _transaction?.Dispose();
                    _transaction = null;
                }
                _disposed = true;
            }
        }

        /// <summary>
        ///     NOTE: Falls irgendwelche unmanaged Ressourcen freigegeben werden müssen, dann muss der Finalizer
        ///     überschrieben werden.
        /// </summary>
        ~SqlTransaction()
        {
            Dispose(false);
        }
    }
}