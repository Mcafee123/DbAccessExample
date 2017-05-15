using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Dapper;
using Dto;
using Util.Interfaces;

namespace RepositoryExample.Daten.Services
{
    public class PersistenceService<T> : IPersistenceService<T> where T : IDto
    {
        private const string GetIdentity = "select cast(scope_identity() as int)";
        private readonly ISessionFactory _sessionFactory;

        public PersistenceService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public T Insert(T item)
        {
            using (var session = _sessionFactory.CreateSqlSession())
            {
                var id = session.Connection.Query<int>(GetInsertCommand(item), item).Single();
                item.Id = id;
                return item;
            }
        }

        public T Update(T item)
        {
            using (var session = _sessionFactory.CreateSqlSession())
            {
                session.Connection.Execute(item.GetUpdateCommand(), item);
                return item;
            }
        }

        public bool Delete(int id)
        {
            using (var session = _sessionFactory.CreateSqlSession())
            {
                var tableName = GetTableName();
                var existing =
                    session.Connection.Query<int>(
                            $"select Id from {tableName} where Id=@id; delete from {tableName} where Id=@id", new {id})
                        .SingleOrDefault();
                return existing > 0;
            }
        }

        public T Select(int id)
        {
            using (var session = _sessionFactory.CreateSqlSession())
            {
                var tableName = GetTableName();
                var dto =
                    session.Connection.Query<T>($"select * from {tableName} where Id=@id", new {id}).SingleOrDefault();
                return dto;
            }
        }

        public IEnumerable<T> Select()
        {
            using (var session = _sessionFactory.CreateSqlSession())
            {
                var tableName = GetTableName();
                var dtos =
                    session.Connection.Query<T>($"select top(500) * from {tableName}");
                return dtos;
            }
        }

        protected string GetInsertCommand(T item, bool returnIdentity = true)
        {
            var itemInsert = item.GetInsertCommand();
            if (returnIdentity)
                itemInsert = $"{itemInsert};{GetIdentity}";
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