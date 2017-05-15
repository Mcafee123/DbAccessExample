using System.Collections.Generic;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.RepositoryExample;
using Dto;
using RepositoryExample.Daten.Services;
using Util.Interfaces;

namespace RepositoryExample.Daten.Repos
{
    public abstract class Repo<T, TDto> : IRepo<T> where TDto : IDto where T : EntityBase
    {
        private readonly ISqlSessionHandler _sqlSessionHandler;
        private readonly IPersistenceService<TDto> _persistenceService;

        protected Repo(ISqlSessionHandler sqlSessionHandler, IPersistenceService<TDto> persistenceService)
        {
            _sqlSessionHandler = sqlSessionHandler;
            _persistenceService = persistenceService;
        }

        public virtual T Add(T item)
        {
            var dto = Map(item);

            _sqlSessionHandler.Write((sessionHandler) => _persistenceService.Insert(dto, sessionHandler.Connection, sessionHandler.Transaction));

            item.Id = dto.Id;
            return item;
        }

        public virtual bool Remove(T item)
        {
            return Remove(item.Id);
        }

        public bool Remove(int id)
        {
            var existed = _sqlSessionHandler.Write((sessionHandler) =>
            {
                return _persistenceService.Delete(id, sessionHandler.Connection, sessionHandler.Transaction);
            });
            return existed;
        }

        public virtual T Update(T item)
        {
            var dto = Map(item);
            _sqlSessionHandler.Write((sessionHandler) => _persistenceService.Update(dto, sessionHandler.Connection, sessionHandler.Transaction));
            return item;
        }

        public virtual T GetById(int id)
        {
            var dto = _sqlSessionHandler.Read((sessionHandler) => _persistenceService.Select(id, sessionHandler.Connection, sessionHandler.Transaction));
            return Map(dto);
        }

        public virtual IEnumerable<T> GetAll()
        {
            var items = _sqlSessionHandler.Read((sessionHandler) => _persistenceService.Select(sessionHandler.Connection, sessionHandler.Transaction));
            foreach (var da in items)
            {
                yield return Map(da);
            }
        }

        protected abstract T Map(TDto dto);
        protected abstract TDto Map(T entity);

        public ISqlSession CreateSqlSession()
        {
            return _sqlSessionHandler.CreateSqlSession();
        }
    }
}