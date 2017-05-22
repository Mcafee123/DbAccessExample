using System.Collections.Generic;
using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.Interfaces.CommandQueryExample
{
    public interface IAblageortEditor
    {
        DossierAblageort Add(DossierAblageort dossierAblageort);
        DossierAblageort Update(DossierAblageort dossierAblageort);
        bool Remove(DossierAblageort dossierAblageort);
        IEnumerable<DossierAblageort> GetAll();
        DossierAblageort GetById(int id);
    }
}
