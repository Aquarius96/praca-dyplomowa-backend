using PracaDyplomowaBackend.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IServiceBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        bool Save();
    }
}
