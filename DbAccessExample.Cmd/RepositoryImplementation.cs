using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.RepositoryExample;
using Ninject;
using RepositoryExample.Daten;
using Util;

namespace DbAccessExample
{
    public class RepositoryImplementation : Implementation
    {
        public RepositoryImplementation() : base(new StandardKernel())
        {
            Kernel.Load(new UtilNinjectModule());
            Kernel.Load(new RepositoryDatenNinjectModule());
        }

        public IDossierEditor GetDossierEditor()
        {
            return Kernel.Get<IDossierEditor>();
        }

        public IDossierAblageortRepo GetAblageortRepo()
        {
            return Kernel.Get<IDossierAblageortRepo>();
        }

        public void AddInitialData()
        {
            // add ablageort
            var ablageOrtRepo = GetAblageortRepo();
            var dossierAblageort = new DossierAblageort
            {
                TextDe = "Beim Kühlschrank DE",
                TextFr = "Beim Kühlschrank FR",
                TextIt = "Beim Kühlschrank IT",
                TextEn = "Beim Kühlschrank EN",
                Typ = 1 // enum nicht in DB definiert?
            };
            
            var kuehlschrank = ablageOrtRepo.Add(dossierAblageort);

            // update
            kuehlschrank.TextDe = "Neben dem Kühlschrank";
            ablageOrtRepo.Update(kuehlschrank);

            // delete
            var existed = ablageOrtRepo.Remove(kuehlschrank);
            var existed2 = ablageOrtRepo.Remove(kuehlschrank.Id);
        }
    }
}