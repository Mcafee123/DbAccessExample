using DbAccessExample.Kern.Interfaces;
using Ninject.Modules;

namespace DbAccessExample.Kern
{
    public class DbAccessExampleKernNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDossierEditor>().To<DossierEditor>();
        }
    }
}