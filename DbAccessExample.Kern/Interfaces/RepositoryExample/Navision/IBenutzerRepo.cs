using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.Interfaces.RepositoryExample.Navision
{
    public interface IBenutzerRepo: IRepo<Benutzer>
    {
        Benutzer GetByFmhId(int i);
    }
}
