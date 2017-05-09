using System.Collections;
using System.Collections.Generic;
using RepositoryExample.Daten.Domain;
using RepositoryExample.Daten.Repos;

namespace RepositoryExample.Kern.Managers
{
    public class DossierEditor
    {
        private readonly IDossierRepo<Dossier> _dossierRepo;

        public DossierEditor(IDossierRepo<Dossier> dossierRepo)
        {
            _dossierRepo = dossierRepo;
        }

        public IEnumerable<Dossier> Search(string searchTerm)
        {
            // query parser...
            // build query...
            return _dossierRepo.Search(searchTerm);
        }
    }
}