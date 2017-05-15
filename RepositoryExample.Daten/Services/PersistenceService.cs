using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using Dapper;
using Dto;

namespace RepositoryExample.Daten.Services
{
    public class PersistenceService<T> : IPersistenceService<T> where T : IDto
    {
        private const string GetIdentity = "select cast(scope_identity() as int)";

        public T Insert(T item, IDbConnection connection, IDbTransaction transaction = null)
        {
            var id = connection.Query<int>(GetInsertCommand(item), item, transaction).Single();
            item.Id = id;
            return item;
        }

        public T Select(int id, IDbConnection connection, IDbTransaction transaction = null)
        {
            var tableName = GetTableName();
            var dto =
                connection.Query<T>($"select * from {tableName} where Id=@id", new {id}, transaction).SingleOrDefault();
            return dto;
        }

        public IEnumerable<T> Select(IDbConnection connection, IDbTransaction transaction = null)
        {
            var tableName = GetTableName();
            var dtos =
                connection.Query<T>($"select top(500) * from {tableName}", null, transaction);
            return dtos;
        }

        public bool Delete(int id, IDbConnection connection, IDbTransaction transaction = null)
        {
            var tableName = GetTableName();
            var existing =
                connection.Query<int>(
                        $"select Id from {tableName} where Id=@id; delete from {tableName} where Id=@id", new {id},
                        transaction)
                    .SingleOrDefault();
            return existing > 0;
        }

        public T Update(T item, IDbConnection connection, IDbTransaction transaction = null)
        {
            connection.Execute(item.GetUpdateCommand(), item, transaction);
            return item;
        }

        protected string GetInsertCommand(T item, bool returnIdentity = true)
        {
            var itemInsert = item.GetInsertCommand();
            if (returnIdentity)
            {
                itemInsert = $"{itemInsert};{GetIdentity}";
            }
            return itemInsert;
        }

        public string GetTableName()
        {
            var dnAttribute = typeof(T).GetCustomAttributes(
                typeof(TableAttribute), true
            ).FirstOrDefault() as TableAttribute;
            return dnAttribute?.Name;
        }
    }
}