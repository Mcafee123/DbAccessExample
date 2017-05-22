using System.Collections.Generic;
using System.Linq;
using CommandQueryExample.Daten.Commands;
using CommandQueryExample.Daten.Queries;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;
using Util.Interfaces;

namespace CommandQueryExample.Daten.Services
{
    public class AblageortService : IAblageortService
    {
        private readonly ISqlSessionHandler _sqlSessionHandler;

        public AblageortService(ISqlSessionHandler sqlSessionHandler)
        {
            _sqlSessionHandler = sqlSessionHandler;
        }

        public DossierAblageort Save(DossierAblageort dossierAblageort)
        {
            _sqlSessionHandler.Execute(new SaveAblageortCommand(dossierAblageort));
            return dossierAblageort;
        }

        public bool Delete(DossierAblageort dossierAblageort)
        {
            var returned =_sqlSessionHandler.Execute(new RemoveAblageortCommand(dossierAblageort.Id));
            return returned > 0;
        }

        public IEnumerable<DossierAblageort> GetAll()
        {
            var ablageorte = _sqlSessionHandler.Query(new GetAblageortQuery());
            foreach (var ablageort in ablageorte)
            {
                yield return new DossierAblageort
                {
                    Id = ablageort.Id,
                    Typ = ablageort.Typ,
                    TextDe = ablageort.TextDE,
                    TextFr = ablageort.TextFR,
                    TextIt = ablageort.TextIT,
                    TextEn = ablageort.TextEN
                };
            }
        }

        public DossierAblageort GetById(int id)
        {
            var ablageort = _sqlSessionHandler.Query(new GetAblageortQuery(id)).SingleOrDefault();
            if (ablageort == null)
            {
                return null;
            }
            return new DossierAblageort
            {
                Id = ablageort.Id,
                Typ = ablageort.Typ,
                TextDe = ablageort.TextDE,
                TextFr = ablageort.TextFR,
                TextIt = ablageort.TextIT,
                TextEn = ablageort.TextEN
            };
        }
    }
}