using Dto;

namespace RepositoryExample.Dapper.Services
{
    public interface IDossierService
    {
        CockpitSB_Dossier LoadDossier(int id);
    }
}