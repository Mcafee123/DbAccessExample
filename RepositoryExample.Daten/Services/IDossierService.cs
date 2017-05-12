using Dto;

namespace RepositoryExample.Daten.Services
{
    public interface IDossierService
    {
        CockpitSB_Dossier LoadDossier(int id);
    }
}