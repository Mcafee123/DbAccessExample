using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.RepositoryExample.CockpitSB;
using DbAccessExample.Kern.RepositoryExample.dbo;
using DbAccessExample.Kern.RepositoryExample.Navision;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using RepositoryExample.Daten.Repos.CockpitSB;
using RepositoryExample.Daten.Repos.dbo;
using RepositoryExample.Daten.Repos.Navision;
using RepositoryExample.Daten.Services;

namespace RepositoryExample.Daten
{
    public class RepositoryDatenNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDossierRepo>().To<DossierRepo>();
            Bind<IDossierService>().To<DossierService>();
            Bind<IDossierFactory>().ToFactory();
            Bind<IDossierAblageortRepo>().To<DossierAblageortRepo>();
            Bind<IBenutzerRepo>().To<BenutzerRepo>();
            Bind(typeof(IPersistenceService<>)).To(typeof(PersistenceService<>));
        }
    }
}