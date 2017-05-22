using System.Collections.Generic;
using System.Data;
using DbAccessExample.Kern.Domain;

namespace RepositoryExample.Daten.Services
{
    public interface IPersistenceService<T>
    {
        T Insert(T item, IDbConnection connection, IDbTransaction transaction = null);
        T Update(T item, IDbConnection connection, IDbTransaction transaction = null);
        bool Delete(int id, IDbConnection connection, IDbTransaction transaction = null);
        T Select(int id, IDbConnection connection, IDbTransaction transaction = null);
        IEnumerable<T> Select(IDbConnection connection, IDbTransaction transaction = null);
        string GetTableName();
    }
}