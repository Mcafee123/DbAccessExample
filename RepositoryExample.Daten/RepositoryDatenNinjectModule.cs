using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.RepositoryExample;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using RepositoryExample.Daten.Repos;
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
        }
    }
}