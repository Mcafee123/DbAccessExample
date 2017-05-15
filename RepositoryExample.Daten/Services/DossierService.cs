using System.Linq;
using Dapper;
using Dto;
using Util.Interfaces;

namespace RepositoryExample.Daten.Services
{
    public class DossierService : IDossierService
    {
        private readonly ISessionFactory _sessionFactory;

        public DossierService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public CockpitSB_Dossier LoadDossier(int dossierId)
        {
            using (var sqlSession = _sessionFactory.CreateSqlSession())
            {
                var unitOfWork = sqlSession.UnitOfWork;
                unitOfWork.Begin();
                try
                {
                    //var sql =
                    //    @"
                    //    select top(1) * from CockpitSB.Dossier where Id = @id
                    //    select * from CockpitSB.DossierVerlauf where DossierId = @id";

                    //var multi = unitOfWork.Connection.QueryMultiple(sql, new {id = dossierId}, unitOfWork.Transaction);
                    //var dossier = multi.Read<CockpitSB_Dossier>().Single();
                    //var orders = multi.Read<CockpitSB_DossierVerlauf>().ToList();
                    var dossier = unitOfWork.Connection.Query<CockpitSB_Dossier>("select * from CockpitSB.Dossier", null, unitOfWork.Transaction).SingleOrDefault();



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