using System;
using System.Data;
using Util.Interfaces;

namespace Util
{
    internal sealed class SqlTransaction : ISqlTransaction
    {
        private readonly IDbConnection _connection;
        private readonly Guid _id;
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
            Console.WriteLine("begin transaction");
        }

        public void Commit()
        {
            Console.WriteLine("commit transaction");
            _transaction.Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            Console.WriteLine("rollback transaction");
            _transaction.Rollback();
        }

        private void Dispose(bool disposing)
        {
            Console.WriteLine($"dispose transaction ({disposing})");
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