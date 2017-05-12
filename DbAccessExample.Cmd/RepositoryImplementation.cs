using Ninject;
using RepositoryExample.Dapper;
using RepositoryExample.Daten;
using RepositoryExample.Kern;
using RepositoryExample.Kern.Interfaces;
using Util;

namespace DbAccessExample
{
    public class RepositoryImplementation : Implementation
    {
        public RepositoryImplementation() : base(new StandardKernel())
        {
            Kernel.Load(new UtilNinjectModule());
            Kernel.Load(new RepositoryDapperNinjectModule());
            Kernel.Load(new RepositoryDatenNinjectModule());
            Kernel.Load(new RepositoryKernNinjectModule());
        }

        public IDossierEditor GetDossierEditor()
        {
            return Kernel.Get<IDossierEditor>();
        }
    }
}