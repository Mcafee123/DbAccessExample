using CommandQueryExample.Daten.Services;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;
using Ninject.Modules;

namespace CommandQueryExample.Daten
{
    public class CmdQueryDatenNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAblageortService>().To<AblageortService>();
            Bind<IBenutzerService>().To<BenutzerService>();
            Bind<IDossierService>().To<DossierService>();
        }
    }
}