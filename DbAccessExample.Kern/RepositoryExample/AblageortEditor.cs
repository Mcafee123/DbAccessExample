using System.Collections.Generic;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;
using DbAccessExample.Kern.Interfaces.RepositoryExample.dbo;

namespace DbAccessExample.Kern.RepositoryExample
{
    public class AblageortEditor : IAblageortEditor
    {
        private readonly IDossierAblageortRepo _ablageortRepo;

        public AblageortEditor(IDossierAblageortRepo ablageortRepo)
        {
            _ablageortRepo = ablageortRepo;
        }

        public DossierAblageort Add(DossierAblageort dossierAblageort)
        {
            return _ablageortRepo.Add(dossierAblageort);
        }

        public DossierAblageort Update(DossierAblageort dossierAblageort)
        {
            return _ablageortRepo.Update(dossierAblageort);
        }

        public bool Remove(DossierAblageort dossierAblageort)
        {
            return Remove(dossierAblageort.Id);
        }

        public IEnumerable<DossierAblageort> GetAll()
        {
            return _ablageortRepo.GetAll();
        }

        public DossierAblageort GetById(int id)
        {
            return _ablageortRepo.GetById(id);
        }

        public bool Remove(int id)
        {
            return _ablageortRepo.Remove(id);
        }
    }
}