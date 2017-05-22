using System.Data;
using Dto;

namespace RepositoryExample.Daten.Services
{
    public interface IDossierService : IPersistenceService<CockpitSB_Dossier>
    {
        int DeleteAll(IDbConnection connection, IDbTransaction transaction);
    }
}