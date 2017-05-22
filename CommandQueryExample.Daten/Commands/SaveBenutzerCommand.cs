using System;
using System.Data;
using System.Linq;
using Dapper;
using DbAccessExample.Kern.Domain;
using Dto;
using Util;

namespace CommandQueryExample.Daten.Commands
{
    public class SaveBenutzerCommand: ICommand
    {
        public Benutzer Benutzer { get; }

        public SaveBenutzerCommand(Benutzer benutzer)
        {
            Benutzer = benutzer;
        }

        public int Execute(IDbConnection connection, IDbTransaction transaction)
        {
            if (Benutzer.Id > 0)
            {
                var sql = Navision_Benutzer.CMD_UPDATE;
                connection.Execute(sql, ParamsObject(), transaction);
            }
            else
            {
                var sql = $"{Navision_Benutzer.CMD_INSERT};select cast(scope_identity() as int)";
                var id = connection.Query<int>(sql, ParamsObject(), transaction).Single();
                Benutzer.Id = id;
            }
            return Benutzer.Id;
        }

        private object ParamsObject()
        {
            string nullString = null;
            DateTime? nullDate = null;
            return new
            {
                Id = Benutzer.Id,
                Adresse1 = Benutzer.Adresse1,
                FMHId = Benutzer.FMHId,
                FMHMember = Benutzer.FMHMember,
                Geschlecht = Benutzer.Geschlecht,
                Name = Benutzer.Name,
                Vorname = Benutzer.Vorname, 
                Sprache = nullString,
                Adresse2 = nullString,
                CoAdresse = nullString,
                Plz = nullString,
                Ort = nullString,
                EMail = nullString,
                Geburtsdatum = nullDate,
                AusbildungDiplomLand = nullString,
                AusbildungDiplomOrt = nullString,
                AusbildungDiplomDatum = nullDate
            };
        }
    }
}
