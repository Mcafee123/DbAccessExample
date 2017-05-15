using System;
using System.Linq;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.RepositoryExample.dbo;
using DbAccessExample.Kern.RepositoryExample.Navision;
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

        private IBenutzerRepo GetBenutzerRepo()
        {
            return Kernel.Get<IBenutzerRepo>();
        }

        public void AddInitialData()
        {
            // add ablageort
            var ablageOrtRepo = GetAblageortRepo();
            var dossierAblageort1 = new DossierAblageort
            {
                TextDe = "Beim Kühlschrank DE",
                TextFr = "Beim Kühlschrank FR",
                TextIt = "Beim Kühlschrank IT",
                TextEn = "Beim Kühlschrank EN",
                Typ = 1 // enum nicht in DB definiert?
            };

            var kuehlschrank1 = ablageOrtRepo.Add(dossierAblageort1);

            // update
            kuehlschrank1.TextDe = "Neben dem Kühlschrank";
            ablageOrtRepo.Update(kuehlschrank1);

            // delete
            var existed = ablageOrtRepo.Remove(kuehlschrank1);
            var existed2 = ablageOrtRepo.Remove(kuehlschrank1.Id);

            // select
            var list = ablageOrtRepo.GetAll().ToList();

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

                var kuehlschrank2 = ablageOrtRepo.Add(dossierAblageort2);
            }
            // select by id
            var entity = ablageOrtRepo.GetById(list.First().Id);
        }

        public void TestException()
        {
            var ablageOrtRepo = GetAblageortRepo();
            var dossierAblageort2 = new DossierAblageort
            {
                TextDe = null, // fail
                TextFr = "Beim Kühlschrank FR",
                TextIt = "Beim Kühlschrank IT",
                TextEn = "Beim Kühlschrank EN",
                Typ = 1 // enum nicht in DB definiert?
            };

            try
            {
                var kuehlschrank2 = ablageOrtRepo.Add(dossierAblageort2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception = ok");
            }
        }

        public void TestRollback()
        {
            var dossierEditor = GetDossierEditor();
            var ablageOrtRepo = GetAblageortRepo();
            var benutzerRepo = GetBenutzerRepo();
            using (var session = ablageOrtRepo.CreateSqlSession())
            {
                session.Begin();
                var ablageorte = ablageOrtRepo.GetAll().ToList();
                DossierAblageort kuehlschrank;
                if (ablageorte.Count < 1)
                {
                    var dossierAblageort = new DossierAblageort
                    {
                        TextDe = "Beim Kühlschrank DE",
                        TextFr = "Beim Kühlschrank FR",
                        TextIt = "Beim Kühlschrank IT",
                        TextEn = "Beim Kühlschrank EN",
                        Typ = 1 // enum nicht in DB definiert?
                    };
                    kuehlschrank = ablageOrtRepo.Add(dossierAblageort);
                }
                else
                {
                    kuehlschrank = ablageorte.First();
                }


                var dossier = new Dossier
                {
                    Ablageort = kuehlschrank
                };
                dossierEditor.Create(dossier);

                session.Commit();
            }
        }
    }
}