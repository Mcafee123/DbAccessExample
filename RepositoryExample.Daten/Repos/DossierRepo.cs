using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.RepositoryExample;
using RepositoryExample.Daten.Services;

namespace RepositoryExample.Daten.Repos
{
    public class DossierRepo : IDossierRepo
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

        public void Add(Dossier item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Dossier item)
        {
            throw new NotImplementedException();
        }

        public void Update(Dossier item)
        {
            throw new NotImplementedException();
        }

        public Dossier FindById(int id)
        {
            var dto = _dossierService.LoadDossier(id);
            return _dossierFactory.CreateDossier();
        }

        public IEnumerable<Dossier> Find(Expression<Func<Dossier, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dossier> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}