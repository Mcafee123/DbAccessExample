using System;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.RepositoryExample.Navision;
using Dto;
using RepositoryExample.Daten.Services;
using Util.Interfaces;

namespace RepositoryExample.Daten.Repos.Navision
{
    public class BenutzerRepo: Repo<Benutzer, Navision_Benutzer>, IBenutzerRepo
    {
        public BenutzerRepo(ISqlSessionHandler sqlSessionHandler, IPersistenceService<Navision_Benutzer> persistenceService) : base(sqlSessionHandler, persistenceService)
        {}

        protected override Benutzer Map(Navision_Benutzer dto)
        {
            throw new NotImplementedException();
        }

        protected override Navision_Benutzer Map(Benutzer entity)
        {
            throw new NotImplementedException();
        }
    }
}
