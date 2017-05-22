using System.Data;
using Dapper;
using Dto;
using Util;

namespace CommandQueryExample.Daten.Commands
{
    public class RemoveBenutzerCommand: ICommand
    {
        private readonly int? _id;

        public RemoveBenutzerCommand(int? id)
        {
            _id = id;
        }

        public int Execute(IDbConnection connection, IDbTransaction transaction)
        {
            var sql = $"delete from {Navision_Benutzer.TABLE_NAME}";
            if (_id.HasValue && _id.Value > 0)
            {
                sql = $"{sql} where Id=@id";
            }
            return connection.Execute(sql, new {id = _id}, transaction);
        }
    }
}
