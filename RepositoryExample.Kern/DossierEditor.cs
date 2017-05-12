using System.Collections.Generic;
using RepositoryExample.Daten.Domain;
using RepositoryExample.Daten.Interfaces.Domain;
using RepositoryExample.Daten.Repos;
using RepositoryExample.Kern.Interfaces;

namespace RepositoryExample.Kern
{
    public class DossierEditor : IDossierEditor
    {
        private readonly IDossierRepo<Dossier> _dossierRepo;

        public DossierEditor(IDossierRepo<Dossier> dossierRepo)
        {
            _dossierRepo = dossierRepo;
        }

        public IDossier LoadDossier(int id)
        {
            return _dossierRepo.LoadDossier(id);
        }

        public IEnumerable<Dossier> Search(string searchTerm)
        {
            // query parser...
            // build query...
            return _dossierRepo.Search(searchTerm);
        }
    }
}