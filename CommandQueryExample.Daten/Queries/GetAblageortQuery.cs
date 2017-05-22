using System.Collections.Generic;
using System.Linq;
using CommandQueryExample.Daten.Interfaces;
using Dapper;
using DbAccessExample.Kern.Domain;
using Dto;
using Util.Interfaces;

namespace CommandQueryExample.Daten.Queries
{
    public class GetAblageortQuery : IQuery<IEnumerable<DossierAblageort>>
    {
        public GetAblageortQuery(int? id = null)
        {
            Id = id;
        }

        public int? Id { get; }

        public IEnumerable<DossierAblageort> Execute(ISqlSessionHandler sessionHandler)
        {
            var ablageorte = sessionHandler.Read<IEnumerable<dbo_DossierAblageort>>(() =>
            {
                var qry = $"select top(500) * from {dbo_DossierAblageort.TABLE_NAME}";
                if (Id.HasValue && Id.Value > 0)
                {
                    qry = $"{qry} where Id=@id";
                }
                var dtos = sessionHandler.Connection.Query<dbo_DossierAblageort>(qry, new {id = Id}).ToList();
                return dtos;
            });
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
    }
}