using DbAccessExample.Kern.Interfaces.Domain;

namespace DbAccessExample.Kern.Interfaces
{
    public interface IDossierEditor
    {
        IDossier LoadDossier(int id);
    }
}