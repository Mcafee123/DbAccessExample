﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DbAccessExample.Kern.RepositoryExample;

namespace RepositoryExample.Daten.Repos
{
    public abstract class Repo<T>: IRepo<T>
    {
        public virtual void Add(T item)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T item)
        {
            throw new NotImplementedException();
        }

        public virtual T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}