using Dto;

namespace RepositoryExample.Dapper.Services
{
    public interface IDossierService
    {
        DossierDto LoadDossier(int id);
    }
}