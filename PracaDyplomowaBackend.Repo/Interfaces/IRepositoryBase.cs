﻿using PracaDyplomowaBackend.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(TId id);
        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        bool Save();
    }
}
