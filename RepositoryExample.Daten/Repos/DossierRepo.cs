using System.Collections.Generic;
using RepositoryExample.Dapper.Services;
using RepositoryExample.Daten.Domain;

namespace RepositoryExample.Daten.Repos
{
    public class DossierRepo : IDossierRepo<Dossier>
    {
        private readonly IDossierService _dossierService;

        public DossierRepo(IDossierService dossierService)
        {
            _dossierService = dossierService;
        }

        public IEnumerable<Dossier> Search(string searchTerm)
        {
            return new List<Dossier>();
        }
    }
}