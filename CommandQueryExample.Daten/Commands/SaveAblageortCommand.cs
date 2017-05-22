using System.Linq;
using CommandQueryExample.Daten.Interfaces;
using Dapper;
using DbAccessExample.Kern.Domain;
using Dto;
using Util.Interfaces;

namespace CommandQueryExample.Daten.Commands
{
    public class SaveAblageortCommand : ICommand
    {
        public SaveAblageortCommand(DossierAblageort dossierAblageort)
        {
            DossierAblageort = dossierAblageort;
        }

        public DossierAblageort DossierAblageort { get; }

        public void Execute(ISqlSessionHandler sessionHandler)
        {
            sessionHandler.Write(() =>
            {
                if (DossierAblageort.Id < 1)
                {
                    var insertCmd = $"{dbo_DossierAblageort.CMD_INSERT};select cast(scope_identity() as int)";
                    var id =
                        sessionHandler.Connection.Query<int>(
                            insertCmd,
                            new
                            {
                                DossierAblageort.Typ,
                                DossierAblageort.TextDe,
                                DossierAblageort.TextFr,
                                DossierAblageort.TextIt,
                                DossierAblageort.TextEn
                            }, sessionHandler.Transaction).Single();
                    DossierAblageort.Id = id;
                }
                else
                {
                    var updateCmd = dbo_DossierAblageort.CMD_UPDATE;
                    sessionHandler.Connection.Execute(updateCmd, new
                    {
                        DossierAblageort.Typ,
                        DossierAblageort.TextDe,
                        DossierAblageort.TextFr,
                        DossierAblageort.TextIt,
                        DossierAblageort.TextEn,
                        DossierAblageort.Id
                    }, sessionHandler.Transaction);
                }
            });
        }
    }
}