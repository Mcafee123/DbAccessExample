using CommandQueryExample.Daten;
using Ninject;
using Util;

namespace DbAccessExample
{
    public class CommandQueryImplementation : Implementation
    {
        public CommandQueryImplementation() : base(new StandardKernel(), false)
        {
            Kernel.Load(new UtilNinjectModule());
            Kernel.Load(new CmdQueryDatenNinjectModule());
        }
    }
}