using System.Linq;
using Dapper;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces.RepositoryExample.Navision;
using Dto;
using RepositoryExample.Daten.Services;
using Util.Interfaces;

namespace RepositoryExample.Daten.Repos.Navision
{
    public class BenutzerRepo : Repo<Benutzer, Navision_Benutzer>, IBenutzerRepo
    {
        public BenutzerRepo(ISqlSessionHandler sqlSessionHandler,
            IPersistenceService<Navision_Benutzer> persistenceService) : base(sqlSessionHandler, persistenceService)
        {}

        public Benutzer GetByFmhId(int fmhId)
        {
            var dto = SqlSessionHandler.RepoQuery(() =>
            {
                var tableName = PersistenceService.GetTableName();
                var benutzer =
                    SqlSessionHandler.Connection.Query<Navision_Benutzer>(
                            $"select * from {tableName} where FmhId=@fmhId", new {fmhId}, SqlSessionHandler.Transaction)
                        .SingleOrDefault();
                return benutzer;
            });
            return dto == null ? null : Map(dto);
        }

        protected override Benutzer Map(Navision_Benutzer dto)
        {
            var entity = new Benutzer
            {
                Id = dto.Id,
                Adresse1 = dto.Adresse1,
                FMHId = dto.FMHId,
                FMHMember = dto.FMHMember,
                Geschlecht = dto.Geschlecht,
                Name = dto.Name,
                Vorname = dto.Vorname
            };
            return entity;
        }

        protected override Navision_Benutzer Map(Benutzer entity)
        {
            var dto = new Navision_Benutzer
            {
                Id = entity.Id,
                Adresse1 = entity.Adresse1,
                FMHId = entity.FMHId,
                FMHMember = entity.FMHMember,
                Geschlecht = entity.Geschlecht,
                Name = entity.Name,
                Vorname = entity.Vorname
            };
            return dto;
        }
    }
}