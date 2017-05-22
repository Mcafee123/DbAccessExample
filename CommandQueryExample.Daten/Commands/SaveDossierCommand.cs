using System;
using System.Data;
using System.Linq;
using Dapper;
using DbAccessExample.Kern.Domain;
using Dto;
using Util;

namespace CommandQueryExample.Daten.Commands
{
    public class SaveDossierCommand : ICommand
    {
        public SaveDossierCommand(Dossier dossier)
        {
            Dossier = dossier;
        }

        public Dossier Dossier { get; }

        public int Execute(IDbConnection connection, IDbTransaction transaction)
        {
            if (Dossier.Id > 0)
            {
                var sql = $"{CockpitSB_Dossier.CMD_UPDATE}";
                connection.Execute(sql, ParamsObject(), transaction);
            }
            else
            {
                var sql = $"{CockpitSB_Dossier.CMD_INSERT};select cast(scope_identity() as int)";
                var id = connection.Query<int>(sql, ParamsObject(), transaction).Single();
                Dossier.Id = id;
            }
            return Dossier.Id;
        }

        private object ParamsObject()
        {
            int? revisionId = null;
            DateTime? nullDate = null;
            string bemerkungen = null;
            return new
            {
                Dossier.Id,
                ArztBenutzerId = Dossier.Arzt?.Id,
                BearbeiterBenutzerId = Dossier.Sachbearbeiterin?.Id,
                RevisionId = revisionId,
                Dossier.DossierStatus,
                Dringend = false,
                Dossier.Typ,
                AblageortId = Dossier.Ablageort.Id,
                KandidatText = "",
                Dossier.ErstelltDatum,
                Dossier.ModifiziertDatum,
                Dossier.ModifiziertBenutzerId,
                GesuchEingangDatum = nullDate,
                PosteingangDatum = nullDate,
                UlaAngefordertDatum = nullDate,
                UlaEingegangenDatum = nullDate,
                AnTitelkommissionDatum = nullDate,
                Bemerkungen = bemerkungen
            };
        }
    }
}