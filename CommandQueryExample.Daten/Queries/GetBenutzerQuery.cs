using System.Collections.Generic;
using System.Data;
using Dapper;
using Dto;
using Util;

namespace CommandQueryExample.Daten.Queries
{
    public class GetBenutzerQuery : IQuery<IEnumerable<Navision_Benutzer>>
    {
        private readonly int? _fmhId;

        public GetBenutzerQuery(int? fmhId = null)
        {
            _fmhId = fmhId;
        }

        public IEnumerable<Navision_Benutzer> Execute(IDbConnection connection, IDbTransaction transaction)
        {
            var sql = $"select * from {Navision_Benutzer.TABLE_NAME}";
            if (_fmhId.HasValue && _fmhId.Value > 0)
            {
                sql = $"{sql} where fmhid=@fmhid";
            }
            return connection.Query<Navision_Benutzer>(sql, new {fmhid = _fmhId}, transaction);
        }
    }
}