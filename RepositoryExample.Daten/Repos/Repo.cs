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
        private readonly IPersistenceService<TDto> _persistenceService;

        protected Repo(ISessionFactory sessionFactory, IPersistenceService<TDto> persistenceService)
        {
            _persistenceService = persistenceService;
            SessionFactory = sessionFactory;
        }

        protected ISessionFactory SessionFactory { get; }

        public virtual T Add(T item)
        {
            var dto = Map(item);
            _persistenceService.Insert(dto);
            item.Id = dto.Id;
            return item;
        }

        public virtual bool Remove(T item)
        {
            return _persistenceService.Delete(item.Id);
        }

        public virtual T Update(T item)
        {
            var dto = Map(item);
            _persistenceService.Update(dto);
            return item;
        }

        public virtual T GetById(int id)
        {
            var dto = _persistenceService.Select(id);
            return Map(dto);
        }

        public virtual IEnumerable<T> GetAll()
        {
            var items = _persistenceService.Select();
            foreach (var da in items)
                yield return Map(da);
        }

        public bool Remove(int id)
        {
            return _persistenceService.Delete(id);
        }

        protected abstract T Map(TDto dto);
        protected abstract TDto Map(T entity);
    }
}