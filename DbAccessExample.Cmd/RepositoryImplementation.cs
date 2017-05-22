using System;
using System.Linq;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces.RepositoryExample.Navision;
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

        private IBenutzerRepo GetBenutzerRepo()
        {
            return Kernel.Get<IBenutzerRepo>();
        }

        public void TestException()
        {
            var ablageOrtRepo = GetAblageortEditor();
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
            var ablageOrtRepo = GetAblageortEditor();
            var benutzerRepo = GetBenutzerRepo();
            using (var session = GetSessionHandler().CreateSqlSession())
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
                var arzt = benutzerRepo.GetByFmhId(12345);
                if (arzt == null)
                {
                    arzt = new Benutzer
                    {
                        Adresse1 = "Strasse 69",
                        FMHId = 12345,
                        FMHMember = true,
                        Geschlecht = 1,
                        Name = "Kandidat",
                        Vorname = "Titel"
                    };
                    benutzerRepo.Add(arzt);
                }
                var sachbearbeiterin = benutzerRepo.GetByFmhId(12345);
                if (sachbearbeiterin == null)
                {
                    sachbearbeiterin = new Benutzer
                    {
                        Adresse1 = "Strasse 696",
                        FMHId = 54321,
                        FMHMember = false,
                        Geschlecht = 1,
                        Name = "Sachbearbeiterin",
                        Vorname = "SIWF"
                    };
                    benutzerRepo.Add(sachbearbeiterin);
                }

                var dossier = new Dossier
                {
                    Ablageort = kuehlschrank,
                    Arzt = arzt,
                    DossierStatus = 1,
                    Dringend = false,
                    ErstelltDatum = DateTime.Now,
                    ModifiziertBenutzerId = 123,
                    ModifiziertDatum = DateTime.Now,
                    Sachbearbeiterin = sachbearbeiterin,
                    Typ = 1
                };
                dossierEditor.Create(dossier);

                session.Commit();
            }
        }
    }
}