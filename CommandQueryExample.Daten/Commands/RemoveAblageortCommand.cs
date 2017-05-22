using System.Linq;
using CommandQueryExample.Daten.Interfaces;
using Dapper;
using Dto;
using Util.Interfaces;

namespace CommandQueryExample.Daten.Commands
{
    public class RemoveAblageortCommand: ICommand
    {
        private int _id;

        public RemoveAblageortCommand(int id)
        {
            _id = id;
        }

        public void Execute(ISqlSessionHandler sessionHandler)
        {
            var existing = sessionHandler.Write(() =>
            {
                var e =
                    sessionHandler.Connection.Query<int>(
                        $"select Id from {dbo_DossierAblageort.TABLE_NAME} where Id=@id; delete from {dbo_DossierAblageort.TABLE_NAME} where Id=@id",
                        new { id = _id}, sessionHandler.Transaction).SingleOrDefault();
                return e > 0;
            });
        }
    }
}
