using System.Collections.Generic;
using RepositoryExample.Daten.Domain;
using RepositoryExample.Daten.Interfaces;
using RepositoryExample.Daten.Services;

namespace RepositoryExample.Daten.Repos
{
    public class DossierRepo : IDossierRepo<Dossier>
    {
        private readonly IDossierFactory _dossierFactory;
        private readonly IDossierService _dossierService;

        public DossierRepo(IDossierService dossierService, IDossierFactory dossierFactory)
        {
            _dossierService = dossierService;
            _dossierFactory = dossierFactory;
        }

        public IEnumerable<Dossier> Search(string searchTerm)
        {
            return new List<Dossier>();
        }

        public Dossier LoadDossier(int id)
        {
            var dto = _dossierService.LoadDossier(id);
            return _dossierFactory.CreateDossier();
        }
    }
}