using Ninject;
using RepositoryExample.Daten;
using Util;

namespace DbAccessExample
{
    public class RepositoryImplementation : Implementation
    {
        public RepositoryImplementation() : base(new StandardKernel(), true)
        {
            Kernel.Load(new UtilNinjectModule());
            Kernel.Load(new RepositoryDatenNinjectModule());
        }
    }
}