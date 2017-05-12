using Dto;
using Util.Interfaces;

namespace RepositoryExample.Dapper.Services
{
    public class DossierService : IDossierService
    {
        private readonly ISessionFactory _sessionFactory;

        public DossierService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public DossierDto LoadDossier(int id)
        {
            using (var sqlSession = _sessionFactory.CreateSqlSession())
            {
                var unitOfWork = sqlSession.UnitOfWork;
                unitOfWork.Begin();
                try
                {
                    //var sql =
                    //    @"
                    //    select * from Customers where CustomerId = @id
                    //    select * from Orders where CustomerId = @id
                    //    select * from Returns where CustomerId = @id";

                    //using (var multi = unitOfWork.Connection.QueryMultiple(sql, new {id = selectedId}))
                    //{
                    //    var customer = multi.Read<Customer>().Single();
                    //    var orders = multi.Read<Order>().ToList();
                    //    var returns = multi.Read<Return>().ToList();
                    //}
                    //Your database code here
                    unitOfWork.Commit();
                }
                catch
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }

            return null;
        }
    }
}