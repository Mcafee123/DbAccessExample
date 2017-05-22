using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dto;
using Util;

namespace CommandQueryExample.Daten.Queries
{
    public class GetAblageortQuery : IQuery<IEnumerable<dbo_DossierAblageort>>
    {
        public GetAblageortQuery(int? id = null)
        {
            Id = id;
        }

        public int? Id { get; }

        public IEnumerable<dbo_DossierAblageort> Execute(IDbConnection connection, IDbTransaction transaction)
        {
            var qry = $"select top(500) * from {dbo_DossierAblageort.TABLE_NAME}";
            if (Id.HasValue && Id.Value > 0)
            {
                qry = $"{qry} where Id=@id";
            }
            var dtos = connection.Query<dbo_DossierAblageort>(qry, new {id = Id}, transaction).ToList();
            return dtos;
        }
    }
}