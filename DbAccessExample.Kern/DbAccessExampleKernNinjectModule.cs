using DbAccessExample.Kern.Interfaces;
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
                Bind<IBenutzerEditor>().To<RepositoryExample.BenutzerEditor>();
            }
            else
            {
                Bind<IAblageortEditor>().To<CommandQueryExample.AblageortEditor>();
                Bind<IDossierEditor>().To<CommandQueryExample.DossierEditor>();
                Bind<IBenutzerEditor>().To<CommandQueryExample.BenutzerEditor>();
            }
        }
    }
}