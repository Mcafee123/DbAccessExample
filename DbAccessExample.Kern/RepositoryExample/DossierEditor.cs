using System.Collections.Generic;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.Interfaces.RepositoryExample.CockpitSB;

namespace DbAccessExample.Kern.RepositoryExample
{
    public class DossierEditor : IDossierEditor
    {
        private readonly IDossierRepo _dossierRepo;

        public DossierEditor(IDossierRepo dossierRepo)
        {
            _dossierRepo = dossierRepo;
        }

        public Dossier LoadDossier(int id)
        {
            return _dossierRepo.GetById(id);
        }

        public Dossier Create(Dossier dossier)
        {
            return _dossierRepo.Add(dossier);
        }

        public IEnumerable<Dossier> Search(string searchTerm)
        {
            // query parser...
            // build query...
            return _dossierRepo.Search(searchTerm);
        }

        public int DeleteAll()
        {
            return _dossierRepo.DeleteAll();
        }
    }
}