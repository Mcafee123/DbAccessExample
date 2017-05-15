using System;
using System.Collections.Generic;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.RepositoryExample.CockpitSB;
using Dto;
using RepositoryExample.Daten.Services;
using Util.Interfaces;

namespace RepositoryExample.Daten.Repos
{
    public class DossierRepo : Repo<Dossier, CockpitSB_Dossier>, IDossierRepo
    {
        private readonly IDossierFactory _dossierFactory;

        public DossierRepo(ISessionFactory sessionFactory, IDossierService dossierService,
            IDossierFactory dossierFactory) : base(sessionFactory, dossierService)
        {
            _dossierFactory = dossierFactory;
        }

        public IEnumerable<Dossier> Search(string searchTerm)
        {
            return new List<Dossier>();
        }

        protected override Dossier Map(CockpitSB_Dossier dto)
        {
            throw new NotImplementedException();
        }

        protected override CockpitSB_Dossier Map(Dossier entity)
        {
            throw new NotImplementedException();
        }
    }
}