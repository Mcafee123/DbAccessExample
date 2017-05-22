using System.Linq;
using DbAccessExample.Kern;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;
using Ninject;
using Util.Interfaces;

namespace DbAccessExample
{
    public abstract class Implementation
    {
        protected Implementation(IKernel kernel, bool useRepositoryExample)
        {
            Kernel = kernel;
            Kernel.Load(new DbAccessExampleKernNinjectModule(useRepositoryExample));
        }

        protected IKernel Kernel { get; }

        public ISqlSessionHandler GetSessionHandler()
        {
            return Kernel.Get<ISqlSessionHandler>();
        }

        public IDossierEditor GetDossierEditor()
        {
            return Kernel.Get<IDossierEditor>();
        }

        public IAblageortEditor GetAblageortEditor()
        {
            return Kernel.Get<IAblageortEditor>();
        }

        public void AddInitialData()
        {
            // add ablageort
            var ablageortEditor = GetAblageortEditor();
            var dossierAblageort1 = new DossierAblageort
            {
                TextDe = "Beim Kühlschrank DE",
                TextFr = "Beim Kühlschrank FR",
                TextIt = "Beim Kühlschrank IT",
                TextEn = "Beim Kühlschrank EN",
                Typ = 1 // enum nicht in DB definiert?
            };

            var kuehlschrank1 = ablageortEditor.Add(dossierAblageort1);

            // update
            kuehlschrank1.TextDe = "Neben dem Kühlschrank";
            ablageortEditor.Update(kuehlschrank1);

            // delete
            var existed = ablageortEditor.Remove(kuehlschrank1);
            var existed2 = ablageortEditor.Remove(kuehlschrank1);

            // select
            var list = ablageortEditor.GetAll().ToList();

            if (list.Count < 1)
            {
                var dossierAblageort2 = new DossierAblageort
                {
                    TextDe = "2. Beim Kühlschrank DE",
                    TextFr = "2. Beim Kühlschrank FR",
                    TextIt = "2. Beim Kühlschrank IT",
                    TextEn = "2. Beim Kühlschrank EN",
                    Typ = 1 // enum nicht in DB definiert?
                };

                var kuehlschrank2 = ablageortEditor.Add(dossierAblageort2);
                list.Add(kuehlschrank2);
            }
            // select by id
            var entity = ablageortEditor.GetById(list.First().Id);
        }
    }
}