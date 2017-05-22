using System.Data;
using Dapper;
using Dto;
using Util;

namespace CommandQueryExample.Daten.Commands
{
    public class RemoveDossierCommand: ICommand
    {
        private readonly int? _id;

        public RemoveDossierCommand(int? id = null)
        {
            _id = id;
        }

        public int Execute(IDbConnection connection, IDbTransaction transaction)
        {
            var sql = $"delete from {CockpitSB_Dossier.TABLE_NAME}";
            if (_id.HasValue && _id.Value > 0)
            {
                sql = $"{sql} where Id=@id";
            }
            return connection.Execute(sql, new {id = _id}, transaction);
        }
    }
}
