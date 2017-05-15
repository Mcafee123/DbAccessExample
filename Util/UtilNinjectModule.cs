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
            Bind<ISqlSessionHandler>().To<SqlSessionHandler>();
            Bind<ISqlSessionFactory>().ToFactory();
            Bind<ISqlSession>().To<SqlSession>();
        }
    }
}