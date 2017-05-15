using System.Collections.Generic;
using Util.Interfaces;

namespace DbAccessExample.Kern.RepositoryExample
{
    public interface IRepo<T>
    {
        T Add(T item);
        bool Remove(T item);
        bool Remove(int id);
        T Update(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        ISqlSession CreateSqlSession();
    }
}