using System.Linq;
using CommandQueryExample.Daten.Commands;
using CommandQueryExample.Daten.Queries;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;
using Util.Interfaces;

namespace CommandQueryExample.Daten.Services
{
    public class BenutzerService: IBenutzerService
    {
        private readonly ISqlSessionHandler _sqlSessionHandler;

        public BenutzerService(ISqlSessionHandler sqlSessionHandler)
        {
            _sqlSessionHandler = sqlSessionHandler;
        }

        public Benutzer GetByFmhId(int fmhId)
        {
            var dto = _sqlSessionHandler.Query(new GetBenutzerQuery(fmhId)).FirstOrDefault();
            if (dto == null)
            {
                return null;
            }
            var benutzer = new Benutzer
            {
                Id = dto.Id,
                Adresse1 = dto.Adresse1,
                FMHId = dto.FMHId,
                FMHMember = dto.FMHMember,
                Geschlecht = dto.Geschlecht,
                Name = dto.Name,
                Vorname = dto.Vorname
            };
            return benutzer;
        }

        public Benutzer Save(Benutzer benutzer)
        {
            _sqlSessionHandler.Execute(new SaveBenutzerCommand(benutzer));
            return benutzer;
        }

        public bool Delete(Benutzer benutzer)
        {
            return _sqlSessionHandler.Execute(new RemoveBenutzerCommand(benutzer.Id)) > 0;
        }
    }
}
