using System.Collections.Generic;
using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.RepositoryExample.CockpitSB
{
    public interface IDossierRepo : IRepo<Dossier>
    {
        IEnumerable<Dossier> Search(string searchTerm);
    }
}