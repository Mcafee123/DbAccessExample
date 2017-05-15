using Dto;
using Util.Interfaces;

namespace RepositoryExample.Daten.Services
{
    public class DossierService : PersistenceService<CockpitSB_Dossier>, IDossierService
    {
        private readonly ISqlSessionFactory _sqlSessionFactory;

        public DossierService(ISqlSessionFactory sqlSessionFactory)
        {
            _sqlSessionFactory = sqlSessionFactory;
        }

        public CockpitSB_Dossier LoadDossier(int dossierId)
        {
            //var sql =
            //    @"
            //    select top(1) * from CockpitSB.Dossier where Id = @id
            //    select * from CockpitSB.DossierVerlauf where DossierId = @id";

            //var multi = unitOfWork.Connection.QueryMultiple(sql, new {id = dossierId}, unitOfWork.Transaction);
            //var dossier = multi.Read<CockpitSB_Dossier>().Single();
            //var orders = multi.Read<CockpitSB_DossierVerlauf>().ToList();
            //var dossier = unitOfWork.Connection.Query<CockpitSB_Dossier>("select * from CockpitSB.Dossier", null, unitOfWork.Transaction).SingleOrDefault();

            return null;
        }
    }
}