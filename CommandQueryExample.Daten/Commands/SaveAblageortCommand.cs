using System.Data;
using System.Linq;
using Dapper;
using DbAccessExample.Kern.Domain;
using Dto;
using Util;

namespace CommandQueryExample.Daten.Commands
{
    public class SaveAblageortCommand : ICommand
    {
        public SaveAblageortCommand(DossierAblageort dossierAblageort)
        {
            DossierAblageort = dossierAblageort;
        }

        public DossierAblageort DossierAblageort { get; }

        public int Execute(IDbConnection connection, IDbTransaction transaction)
        {
            if (DossierAblageort.Id < 1)
            {
                var insertCmd = $"{dbo_DossierAblageort.CMD_INSERT};select cast(scope_identity() as int)";
                var id =
                    connection.Query<int>(
                        insertCmd,
                        new
                        {
                            DossierAblageort.Typ,
                            DossierAblageort.TextDe,
                            DossierAblageort.TextFr,
                            DossierAblageort.TextIt,
                            DossierAblageort.TextEn
                        }, transaction).Single();
                DossierAblageort.Id = id;
            }
            else
            {
                var updateCmd = dbo_DossierAblageort.CMD_UPDATE;
                connection.Execute(updateCmd, new
                {
                    DossierAblageort.Typ,
                    DossierAblageort.TextDe,
                    DossierAblageort.TextFr,
                    DossierAblageort.TextIt,
                    DossierAblageort.TextEn,
                    DossierAblageort.Id
                }, transaction);
            }
            return DossierAblageort.Id;
        }
    }
}