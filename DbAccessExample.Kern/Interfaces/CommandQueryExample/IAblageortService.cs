using System.Collections.Generic;
using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.Interfaces.CommandQueryExample
{
    public interface IAblageortService
    {
        DossierAblageort Save(DossierAblageort dossierAblageort);
        bool Delete(DossierAblageort dossierAblageort);
        IEnumerable<DossierAblageort> GetAll();
        DossierAblageort GetById(int id);
    }
}
