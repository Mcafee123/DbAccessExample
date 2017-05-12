using Ninject;

namespace DbAccessExample
{
    public abstract class Implementation
    {
        protected Implementation(IKernel kernel)
        {
            Kernel = kernel;
        }

        protected IKernel Kernel { get; }
    }
}