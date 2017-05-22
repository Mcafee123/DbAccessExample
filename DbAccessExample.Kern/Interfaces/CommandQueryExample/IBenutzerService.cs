using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.Interfaces.CommandQueryExample
{
    public interface IBenutzerService
    {
        Benutzer GetByFmhId(int fmhId);
        Benutzer Save(Benutzer benutzer);
        bool Delete(Benutzer benutzer);
    }
}