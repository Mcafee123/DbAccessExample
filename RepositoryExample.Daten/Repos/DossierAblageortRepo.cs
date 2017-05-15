using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.RepositoryExample.dbo;
using Dto;
using RepositoryExample.Daten.Services;
using Util.Interfaces;

namespace RepositoryExample.Daten.Repos
{
    public class DossierAblageortRepo : Repo<DossierAblageort, dbo_DossierAblageort>, IDossierAblageortRepo
    {
        public DossierAblageortRepo(ISessionFactory sessionFactory,
            IPersistenceService<dbo_DossierAblageort> persistenceService) : base(sessionFactory, persistenceService)
        {
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