using System.Collections.Generic;

namespace RepositoryExample.Daten.Services
{
    public interface IPersistenceService<T>
    {
        T Insert(T item);
        T Update(T item);
        bool Delete(int id);
        T Select(int id);
        IEnumerable<T> Select();
    }
}