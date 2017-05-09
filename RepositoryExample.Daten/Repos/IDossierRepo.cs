using System.Collections.Generic;

namespace RepositoryExample.Daten.Repos
{
    public interface IDossierRepo<Dossier>: IRepo<Dossier>
    {
        IEnumerable<Dossier> Search(string searchTerm);
    }

    public interface IRepo<T>
    {
    }
}