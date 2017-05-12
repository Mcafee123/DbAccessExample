using Ninject.Modules;
using RepositoryExample.Dapper.Services;

namespace RepositoryExample.Dapper
{
    public class RepositoryDapperNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDossierService>().To<DossierService>();
        }
    }
}