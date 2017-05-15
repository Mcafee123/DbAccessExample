using System.Data;
using System.Data.SqlClient;
using Util.Interfaces;

namespace Util
{
    public sealed class SqlSession : ISqlSession
    {
        public SqlSession(IConfigReader rd)
        {
            Connection = new SqlConnection(rd.GetConnectionString());
            Connection.Open();
            UnitOfWork = new UnitOfWork(Connection);
        }

        public IDbConnection Connection { get; }

        public IUnitOfWork UnitOfWork { get; }

        public void Dispose()
        {
            UnitOfWork.Dispose();
            Connection.Dispose();
        }
    }
}