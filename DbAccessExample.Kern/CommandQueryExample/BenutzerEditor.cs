using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;

namespace DbAccessExample.Kern.CommandQueryExample
{
    public class BenutzerEditor: IBenutzerEditor
    {
        private readonly IBenutzerService _benutzerService;

        public BenutzerEditor(IBenutzerService benutzerService)
        {
            _benutzerService = benutzerService;
        }

        public Benutzer GetByFmhId(int fmhId)
        {
            return _benutzerService.GetByFmhId(fmhId);
        }

        public Benutzer Add(Benutzer benutzer)
        {
            return _benutzerService.Save(benutzer);
        }

        public bool Delete(Benutzer benutzer)
        {
            return _benutzerService.Delete(benutzer);
        }
    }
}
