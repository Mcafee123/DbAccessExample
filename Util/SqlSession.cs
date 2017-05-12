using System.Data;
using System.Data.SqlClient;
using Util.Interfaces;

namespace Util
{
    public sealed class SqlSession : ISqlSession
    {
        private readonly IDbConnection _connection;

        public SqlSession(IConfigReader rd)
        {
            _connection = new SqlConnection(rd.GetConnectionString());
            _connection.Open();
            UnitOfWork = new UnitOfWork(_connection);
        }

        public IUnitOfWork UnitOfWork { get; }

        public void Dispose()
        {
            UnitOfWork.Dispose();
            _connection.Dispose();
        }
    }
}