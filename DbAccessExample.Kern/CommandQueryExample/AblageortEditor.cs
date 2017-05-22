using System.Collections.Generic;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;

namespace DbAccessExample.Kern.CommandQueryExample
{
    public class AblageortEditor: IAblageortEditor
    {
        private readonly IAblageortService _ablageortService;

        public AblageortEditor(IAblageortService ablageortService)
        {
            _ablageortService = ablageortService;
        }

        public DossierAblageort Add(DossierAblageort dossierAblageort)
        {
            return _ablageortService.Save(dossierAblageort);
        }

        public DossierAblageort Update(DossierAblageort dossierAblageort)
        {
            return _ablageortService.Save(dossierAblageort);
        }

        public bool Remove(DossierAblageort dossierAblageort)
        {
            return _ablageortService.Delete(dossierAblageort);
        }

        public IEnumerable<DossierAblageort> GetAll()
        {
            return _ablageortService.GetAll();
        }

        public DossierAblageort GetById(int id)
        {
            return _ablageortService.GetById(id);
        }
    }
}
