using System;
using System.Linq;
using DbAccessExample.Kern;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
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

        public IBenutzerEditor GetBenutzerEditor()
        {
            return Kernel.Get<IBenutzerEditor>();
        }

        public void AddInitialDataTransaction()
        {
            var sessionHandler = GetSessionHandler();
            using (var session = sessionHandler.CreateSqlSession())
            {
                session.Begin();
                AddInitialData();
                session.Commit();
            }
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

        public void TestException()
        {
            var ablageortEditor = GetAblageortEditor();
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
                var kuehlschrank2 = ablageortEditor.Add(dossierAblageort2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception = ok");
            }
        }

        public void TestRollback(bool doRollbackByMakingError, int arztFmhId, int sachbearbeiterId)
        {
            var dossierEditor = GetDossierEditor();
            var ablageortEditor = GetAblageortEditor();
            var benutzerEditor = GetBenutzerEditor();
            using (var session = GetSessionHandler().CreateSqlSession())
            {
                session.Begin();
                try
                {
                    var ablageorte = ablageortEditor.GetAll().ToList();
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
                        kuehlschrank = ablageortEditor.Add(dossierAblageort);
                    }
                    else
                    {
                        kuehlschrank = ablageorte.First();
                    }
                    var arzt = benutzerEditor.GetByFmhId(arztFmhId);
                    if (arzt == null)
                    {
                        arzt = new Benutzer
                        {
                            Adresse1 = "Strasse 69",
                            FMHId = arztFmhId,
                            FMHMember = true,
                            Geschlecht = 1,
                            Name = "Kandidat",
                            Vorname = "Titel"
                        };
                        benutzerEditor.Add(arzt);
                    }
                    var sachbearbeiterin = benutzerEditor.GetByFmhId(sachbearbeiterId);
                    if (sachbearbeiterin == null)
                    {
                        sachbearbeiterin = new Benutzer
                        {
                            Adresse1 = "Strasse 696",
                            FMHId = sachbearbeiterId,
                            FMHMember = false,
                            Geschlecht = 1,
                            Name = "Sachbearbeiterin",
                            Vorname = "SIWF"
                        };
                        benutzerEditor.Add(sachbearbeiterin);
                    }

                    dossierEditor.DeleteAll();

                    if (doRollbackByMakingError)
                    {
                        benutzerEditor.Delete(sachbearbeiterin);
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
                catch
                {
                    session.SqlTransaction?.Rollback();
                    if (doRollbackByMakingError)
                    {
                        Console.WriteLine("exception = ok");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}