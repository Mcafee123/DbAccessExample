using System;
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
            var sql = GetInsertCommand(item);
            Console.WriteLine("---");
            Console.WriteLine(sql);
            Console.WriteLine("---");
            var id = connection.Query<int>(sql, item, transaction).Single();
            item.Id = id;
            return item;
        }

        public T Select(int id, IDbConnection connection, IDbTransaction transaction = null)
        {
            var tableName = GetTableName();
            var sql = $"select * from {tableName} where Id=@id";
            Console.WriteLine("---");
            Console.WriteLine(sql);
            Console.WriteLine("---");
            var dto =
                connection.Query<T>(sql, new {id}, transaction).SingleOrDefault();
            return dto;
        }

        public IEnumerable<T> Select(IDbConnection connection, IDbTransaction transaction = null)
        {
            var tableName = GetTableName();
            var sql = $"select top(500) * from {tableName}";
            Console.WriteLine("---");
            Console.WriteLine(sql);
            Console.WriteLine("---");
            var dtos =
                connection.Query<T>(sql, null, transaction);
            return dtos;
        }

        public bool Delete(int id, IDbConnection connection, IDbTransaction transaction = null)
        {
            var tableName = GetTableName();
            var sql = $"delete from {tableName} where Id=@id";
            Console.WriteLine("---");
            Console.WriteLine(sql);
            Console.WriteLine("---");
            var existing = connection.Execute(sql, new {id}, transaction);
            return existing > 0;
        }

        public T Update(T item, IDbConnection connection, IDbTransaction transaction = null)
        {
            var sql = item.GetUpdateCommand();
            Console.WriteLine("---");
            Console.WriteLine(sql);
            Console.WriteLine("---");
            connection.Execute(sql, item, transaction);
            return item;
        }

        public string GetTableName()
        {
            var dnAttribute = typeof(T).GetCustomAttributes(
                typeof(TableAttribute), true
            ).FirstOrDefault() as TableAttribute;
            return dnAttribute?.Name;
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
    }
}