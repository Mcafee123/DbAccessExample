using System;
using System.Collections.Generic;
using System.Data;
using DbAccessExample.Kern.Domain;
using Util;

namespace CommandQueryExample.Daten.Queries
{
    public class GetDossierQuery : IQuery<IEnumerable<Dossier>>
    {
        public IEnumerable<Dossier> Execute(IDbConnection connection, IDbTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}