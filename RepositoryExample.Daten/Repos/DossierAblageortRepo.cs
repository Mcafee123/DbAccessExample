using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.RepositoryExample;
using Dto;

namespace RepositoryExample.Daten.Repos
{
    public class DossierAblageortRepo : IDossierAblageortRepo
    {
        public void Add(DossierAblageort item)
        {
            throw new NotImplementedException();
        }

        public void Remove(DossierAblageort item)
        {
            throw new NotImplementedException();
        }

        public void Update(DossierAblageort item)
        {
            throw new NotImplementedException();
        }

        public DossierAblageort FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DossierAblageort> Find(Expression<Func<DossierAblageort, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DossierAblageort> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}