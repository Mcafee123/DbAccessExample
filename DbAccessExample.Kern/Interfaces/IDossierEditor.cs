using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.Interfaces
{
    public interface IDossierEditor
    {
        Dossier LoadDossier(int id);
    }
}