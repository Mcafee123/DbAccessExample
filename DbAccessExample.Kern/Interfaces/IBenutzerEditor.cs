using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.Interfaces
{
    public interface IBenutzerEditor
    {
        Benutzer GetByFmhId(int fmhId);
        Benutzer Add(Benutzer arzt);
        bool Delete(Benutzer sachbearbeiterin);
    }
}