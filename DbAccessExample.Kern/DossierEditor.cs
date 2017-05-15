using System.Collections.Generic;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.Interfaces.Domain;
using DbAccessExample.Kern.RepositoryExample;

namespace DbAccessExample.Kern
{
    public class DossierEditor : IDossierEditor
    {
        private readonly IDossierRepo _dossierRepo;

        public DossierEditor(IDossierRepo dossierRepo)
        {
            _dossierRepo = dossierRepo;
        }

        public IDossier LoadDossier(int id)
        {
            return _dossierRepo.GetById(id);
        }

        public IEnumerable<Dossier> Search(string searchTerm)
        {
            // query parser...
            // build query...
            return _dossierRepo.Search(searchTerm);
        }
    }
}