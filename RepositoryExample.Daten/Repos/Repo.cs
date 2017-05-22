using System;
using System.Collections.Generic;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces.RepositoryExample;
using Dto;
using RepositoryExample.Daten.Services;
using Util.Interfaces;

namespace RepositoryExample.Daten.Repos
{
    public abstract class Repo<T, TDto> : IRepo<T> where TDto : IDto where T : EntityBase
    {
        protected readonly IPersistenceService<TDto> PersistenceService;
        protected readonly ISqlSessionHandler SqlSessionHandler;

        protected Repo(ISqlSessionHandler sqlSessionHandler, IPersistenceService<TDto> persistenceService)
        {
            SqlSessionHandler = sqlSessionHandler;
            PersistenceService = persistenceService;
        }

        public virtual T Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            var dto = Map(item);

            SqlSessionHandler.RepoQuery(
                () => PersistenceService.Insert(dto, SqlSessionHandler.Connection, SqlSessionHandler.Transaction));

            item.Id = dto.Id;
            return item;
        }

        public bool Remove(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("cannot be smaller than 1", nameof(id));
            }
            var existed =
                SqlSessionHandler.RepoQuery(
                    () =>
                    {
                        return PersistenceService.Delete(id, SqlSessionHandler.Connection, SqlSessionHandler.Transaction);
                    });
            return existed;
        }

        public virtual T Update(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            var dto = Map(item);
            SqlSessionHandler.RepoQuery(
                () => PersistenceService.Update(dto, SqlSessionHandler.Connection, SqlSessionHandler.Transaction));
            return item;
        }

        public virtual T GetById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("cannot be smaller than 1", nameof(id));
            }
            var dto =
                SqlSessionHandler.RepoQuery(
                    () => PersistenceService.Select(id, SqlSessionHandler.Connection, SqlSessionHandler.Transaction));
            return dto == null ? null : Map(dto);
        }

        public virtual IEnumerable<T> GetAll()
        {
            var items =
                SqlSessionHandler.RepoQuery(
                    () => PersistenceService.Select(SqlSessionHandler.Connection, SqlSessionHandler.Transaction));
            foreach (var da in items)
            {
                yield return Map(da);
            }
        }

        public ISqlSession CreateSqlSession()
        {
            return SqlSessionHandler.CreateSqlSession();
        }

        protected abstract T Map(TDto dto);
        protected abstract TDto Map(T entity);
    }
}