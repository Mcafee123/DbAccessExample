using RepositoryExample.Dapper.Dto;
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