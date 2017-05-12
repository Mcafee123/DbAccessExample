using System;
using CommandQueryExample.Daten;
using CommandQueryExample.Kern;
using Ninject;

namespace CommandQueryExample.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            // get assemblies
            IKernel kernel = new StandardKernel();
            kernel.Load(new DatenNinjectModule());

            kernel.Bind<DossierEditor>().To<DossierEditor>();

            var dossierEditor = kernel.Get<DossierEditor>();

            Console.ReadKey();
        }
    }
}
