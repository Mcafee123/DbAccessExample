using System.Data;
using Dapper;
using Dto;
using Util;

namespace CommandQueryExample.Daten.Commands
{
    public class RemoveAblageortCommand : ICommand
    {
        private readonly int _id;

        public RemoveAblageortCommand(int id)
        {
            _id = id;
        }

        public int Execute(IDbConnection connection, IDbTransaction transaction)
        {
            return connection.Execute($"delete from {dbo_DossierAblageort.TABLE_NAME} where Id=@id", new {id = _id},
                transaction);
        }
    }
}