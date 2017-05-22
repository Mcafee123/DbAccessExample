using CommandQueryExample.Daten.Commands;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;
using Util.Interfaces;

namespace CommandQueryExample.Daten.Services
{
    public class DossierService: IDossierService
    {
        private readonly ISqlSessionHandler _sqlSessionHandler;

        public DossierService(ISqlSessionHandler sqlSessionHandler)
        {
            _sqlSessionHandler = sqlSessionHandler;
        }

        public int DeleteAll()
        {
            return _sqlSessionHandler.Execute(new RemoveDossierCommand());
        }

        public Dossier Create(Dossier dossier)
        {
            _sqlSessionHandler.Execute(new SaveDossierCommand(dossier));
            return dossier;
        }
    }
}
