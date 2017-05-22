using System;
using System.Collections.Generic;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces.RepositoryExample.CockpitSB;
using Dto;
using RepositoryExample.Daten.Services;
using Util.Interfaces;

namespace RepositoryExample.Daten.Repos.CockpitSB
{
    public class DossierRepo : Repo<Dossier, CockpitSB_Dossier>, IDossierRepo
    {
        private readonly IDossierService _dossierService;
        private readonly IPersistenceService<dbo_DossierAblageort> _ablageortService;
        private readonly IPersistenceService<Navision_Benutzer> _benutzerService;

        public DossierRepo(ISqlSessionHandler sqlSessionHandler, IDossierService dossierService,
            IPersistenceService<dbo_DossierAblageort> ablageortService, IPersistenceService<Navision_Benutzer> benutzerService)
            : base(sqlSessionHandler, dossierService)
        {
            _dossierService = dossierService;
            _ablageortService = ablageortService;
            _benutzerService = benutzerService;
        }

        public IEnumerable<Dossier> Search(string searchTerm)
        {
            using (var session = CreateSqlSession())
            {
                session.Begin();


            }
            return null;
        }

        protected override Dossier Map(CockpitSB_Dossier dto)
        {
            var entity = new Dossier
            {
                Id = dto.Id,
                Ablageort = null,
                Arzt = null, 
                DossierStatus = dto.DossierStatus,
                Dringend = dto.Dringend,
                ErstelltDatum = dto.ErstelltDatum,
                ModifiziertBenutzerId = dto.ModifiziertBenutzerId,
                ModifiziertDatum = dto.ModifiziertDatum,
                Sachbearbeiterin = null,
                Typ = dto.Typ
            };
            return entity;
        }

        protected override CockpitSB_Dossier Map(Dossier entity)
        {
            var dto = new CockpitSB_Dossier {
                Id = entity.Id,
                AblageortId = entity.Ablageort?.Id,
                ArztBenutzerId = entity.Arzt.Id,
                BearbeiterBenutzerId=  entity.Sachbearbeiterin.Id,
                DossierStatus = entity.DossierStatus,
                Dringend = entity.Dringend,
                ErstelltDatum = entity.ErstelltDatum,
                ModifiziertBenutzerId = entity.ModifiziertBenutzerId,
                ModifiziertDatum = entity.ModifiziertDatum,
                Typ = entity.Typ

            };
            return dto;
        }
    }
}