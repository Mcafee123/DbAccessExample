using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.RepositoryExample.dbo;
using Dto;
using RepositoryExample.Daten.Services;
using Util.Interfaces;

namespace RepositoryExample.Daten.Repos.dbo
{
    public class DossierAblageortRepo : Repo<DossierAblageort, dbo_DossierAblageort>, IDossierAblageortRepo
    {
        public DossierAblageortRepo(ISqlSessionHandler sqlSessionHandler,
            IPersistenceService<dbo_DossierAblageort> persistenceService) : base(sqlSessionHandler, persistenceService)
        {}

        public void DoSomeTransactionStuff()
        {
            using (var session = CreateSqlSession())
            {
                session.Begin();

                var dossierAblageort1 = new DossierAblageort
                {
                    TextDe = "Beim Kühlschrank DE",
                    TextFr = "Beim Kühlschrank FR",
                    TextIt = "Beim Kühlschrank IT",
                    TextEn = "Beim Kühlschrank EN",
                    Typ = 1 // enum nicht in DB definiert?
                };

                var kuehlschrank1 = Add(dossierAblageort1);

                var dossierAblageort2 = new DossierAblageort
                {
                    TextDe = "Beim Kühlschrank DE",
                    TextFr = "Beim Kühlschrank FR",
                    TextIt = "Beim Kühlschrank IT",
                    TextEn = "Beim Kühlschrank EN",
                    Typ = 1 // enum nicht in DB definiert?
                };

                var kuehlschrank2 = Add(dossierAblageort2);

                session.Commit();
            }
        }

        protected override dbo_DossierAblageort Map(DossierAblageort entity)
        {
            var dto = new dbo_DossierAblageort
            {
                Id = entity.Id,
                Typ = entity.Typ,
                TextDE = entity.TextDe,
                TextFR = entity.TextFr,
                TextIT = entity.TextIt,
                TextEN = entity.TextEn
            };
            return dto;
        }

        protected override DossierAblageort Map(dbo_DossierAblageort dto)
        {
            var entity = new DossierAblageort
            {
                Id = dto.Id,
                Typ = dto.Typ,
                TextDe = dto.TextDE,
                TextFr = dto.TextFR,
                TextIt = dto.TextIT,
                TextEn = dto.TextEN
            };
            return entity;
        }
    }
}