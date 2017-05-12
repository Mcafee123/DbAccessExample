using CommandQueryExample.Daten;
using CommandQueryExample.Kern;
using Ninject;
using Util;

namespace DbAccessExample
{
    public class CmdQueryImplementation : Implementation
    {
        public CmdQueryImplementation() : base(new StandardKernel())
        {
            Kernel.Load(new UtilNinjectModule());
            Kernel.Load(new CmdQueryDatenNinjectModule());
            Kernel.Load(new CmdQueryKernNinjectModule());
        }
    }
}