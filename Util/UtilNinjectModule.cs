using Ninject.Extensions.Factory;
using Ninject.Modules;
using Util.Interfaces;

namespace Util
{
    public class UtilNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigReader>().To<ConfigReader>();
            Bind<ISessionFactory>().ToFactory();
            Bind<ISqlSession>().To<SqlSession>();
        }
    }
}