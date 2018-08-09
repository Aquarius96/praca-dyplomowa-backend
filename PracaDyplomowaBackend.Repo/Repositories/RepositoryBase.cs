using Microsoft.EntityFrameworkCore;
using PracaDyplomowaBackend.Data.DbModels;
using PracaDyplomowaBackend.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public abstract class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        private readonly DataContext _context;

        protected RepositoryBase(DataContext context)
        {
            _context = context;
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

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
