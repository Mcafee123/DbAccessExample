using System.Collections.Generic;
using CommandQueryExample.Daten.Interfaces;
using DbAccessExample.Kern.Domain;
using Util.Interfaces;

namespace CommandQueryExample.Daten.Queries
{
    public class GetDossierQuery : IQuery<IEnumerable<Dossier>>
    {
        public IEnumerable<Dossier> Execute(ISqlSessionHandler sessionHandler)
        {
            
        }
    }
}
