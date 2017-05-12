using RepositoryExample.Daten.Interfaces.Domain;

namespace RepositoryExample.Kern.Interfaces
{
    public interface IDossierEditor
    {
        IDossier LoadDossier(int id);
    }
}