using System;
using System.Data;
using Util.Interfaces;

namespace Util
{
    public sealed class SqlSession : IDisposable
    {
        private readonly IDbConnection _connection;

        public SqlSession(IConfigReader rd)
        {
            //_connection = new SqlConnection(DalCommon.ConnectionString);
            //_connection.Open();
            //UnitOfWork = new UnitOfWork(_connection);
        }

        //public UnitOfWork UnitOfWork { get; } = null;

        public void Dispose()
        {
            //UnitOfWork.Dispose();
            //_connection.Dispose();
        }
    }
}