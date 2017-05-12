using Ninject.Modules;
using RepositoryExample.Kern.Interfaces;

namespace RepositoryExample.Kern
{
    public class RepositoryKernNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDossierEditor>().To<DossierEditor>();
        }
    }
}