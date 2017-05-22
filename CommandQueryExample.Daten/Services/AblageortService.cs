using System.Collections.Generic;
using System.Linq;
using CommandQueryExample.Daten.Commands;
using CommandQueryExample.Daten.Queries;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;
using Util.Interfaces;

namespace CommandQueryExample.Daten.Services
{
    public class AblageortService: IAblageortService
    {
        private readonly ISqlSessionHandler _sqlSessionHandler;

        public AblageortService(ISqlSessionHandler sqlSessionHandler)
        {
            _sqlSessionHandler = sqlSessionHandler;
        }

        public DossierAblageort Save(DossierAblageort dossierAblageort)
        {
            new SaveAblageortCommand(dossierAblageort).Execute(_sqlSessionHandler);
            return dossierAblageort;
        }

        public bool Delete(DossierAblageort dossierAblageort)
        {
            new RemoveAblageortCommand(dossierAblageort.Id).Execute(_sqlSessionHandler);
            return true;
        }

        public IEnumerable<DossierAblageort> GetAll()
        {
            return new GetAblageortQuery().Execute(_sqlSessionHandler);
        }

        public DossierAblageort GetById(int id)
        {
            return new GetAblageortQuery(id).Execute(_sqlSessionHandler).SingleOrDefault();
        }
    }
}
