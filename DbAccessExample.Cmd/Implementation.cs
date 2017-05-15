using DbAccessExample.Kern;
using Ninject;

namespace DbAccessExample
{
    public abstract class Implementation
    {
        protected Implementation(IKernel kernel)
        {
            Kernel = kernel;
            Kernel.Load(new DbAccessExampleKernNinjectModule());
        }

        protected IKernel Kernel { get; }
    }
}