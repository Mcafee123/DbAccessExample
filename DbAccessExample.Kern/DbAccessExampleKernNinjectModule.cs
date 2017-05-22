using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;
using DbAccessExample.Kern.Interfaces.RepositoryExample.dbo;
using Ninject.Modules;

namespace DbAccessExample.Kern
{
    public class DbAccessExampleKernNinjectModule : NinjectModule
    {
        private readonly bool _useRepositoryExample;

        public DbAccessExampleKernNinjectModule(bool useRepositoryExample)
        {
            _useRepositoryExample = useRepositoryExample;
        }

        public override void Load()
        {
            if (_useRepositoryExample)
            {
                Bind<IAblageortEditor>().To<RepositoryExample.AblageortEditor>();
                Bind<IDossierEditor>().To<RepositoryExample.DossierEditor>();
            }
            else
            {
                Bind<IAblageortEditor>().To<CommandQueryExample.AblageortEditor>();
                Bind<IDossierEditor>().To<CommandQueryExample.DossierEditor>();
            }
        }
    }
}