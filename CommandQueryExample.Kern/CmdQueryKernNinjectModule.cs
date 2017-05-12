using CommandQueryExample.Kern.Interfaces.Domain;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace CommandQueryExample.Kern
{
    public class CmdQueryKernNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDossierFactory>().ToFactory();
        }
    }
}