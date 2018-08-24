﻿using Microsoft.EntityFrameworkCore;
using PracaDyplomowaBackend.Data.DbModels;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Paging;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public abstract class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        protected readonly DataContext _context;
        protected readonly IStringProvider _stringProvider;

        public RepositoryBase(DataContext context, IStringProvider stringProvider)
        {
            _context = context;
            _stringProvider = stringProvider;
        }

        public void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }

        public TEntity Get(TId id)
        {
            return _context.Set<TEntity>().FirstOrDefault(entity => entity.Id.Equals(id));
        }

        public IEnumerable<TEntity> GetList()
        {
            return _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetList(ResourceParameters resourceParameters)
        {
            var entities = _context.Set<TEntity>().Where(entity => resourceParameters.SearchProperties.Any(property => _stringProvider.PropertyContainsQuery(entity.GetType().GetProperty(property).GetValue(entity, null).ToString(), resourceParameters.SearchQuery)))
            .Skip(resourceParameters.PageSize * (resourceParameters.PageNumber - 1))
            .Take(resourceParameters.PageSize);

            return entities;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
