using System;
using System.Data;
using System.Data.SqlClient;
using Util.Interfaces;

namespace Util
{
    internal sealed class SqlSession : ISqlSession
    {
        private bool _disposed;

        public SqlSession(IConfigReader rd)
        {
            Console.WriteLine("===");
            Console.WriteLine("create session and open connection");
            Connection = new SqlConnection(rd.GetConnectionString());
            Connection.Open();
        }

        public bool HasTransaction => SqlTransaction?.Transaction != null;

        public IDbConnection Connection { get; private set; }

        public ISqlTransaction SqlTransaction { get; private set; }

        public void Begin()
        {
            SqlTransaction = new SqlTransaction(Connection);
            SqlTransaction.Begin();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            SqlTransaction.Commit();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Transaction Dispose (wenn noch da...)
                    SqlTransaction?.Dispose();
                    SqlTransaction = null;

                    // Connection Dispose
                    Console.WriteLine("dispose session");
                    Connection?.Close();
                    Connection?.Dispose();
                    Connection = null;
                    Console.WriteLine("===");
                }
                _disposed = true;
            }
        }

        ~SqlSession()
        {
            Dispose(false);
        }
    }
}