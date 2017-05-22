using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.Interfaces.CommandQueryExample
{
    public interface IDossierService
    {
        int DeleteAll();
        Dossier Create(Dossier dossier);
    }
}