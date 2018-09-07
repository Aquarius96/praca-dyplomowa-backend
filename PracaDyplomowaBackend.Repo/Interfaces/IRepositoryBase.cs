using PracaDyplomowaBackend.Data.DbModels;
using PracaDyplomowaBackend.Utilities.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        bool ListExists(IEnumerable<TId> ids);
        TEntity Get(TId id);
        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetList(ResourceParameters resourceParameters);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        bool Save();
    }
}
