﻿using Ninject.Modules;
using RepositoryExample.Daten.Domain;
using RepositoryExample.Daten.Repos;

namespace RepositoryExample.Daten
{
    public class RepositoryDatenNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDossierRepo<Dossier>>().To<DossierRepo>();
        }
    }
}