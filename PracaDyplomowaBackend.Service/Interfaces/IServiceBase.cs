using PracaDyplomowaBackend.Data.DbModels;
using PracaDyplomowaBackend.Models.Models;
using PracaDyplomowaBackend.Models.ModelsDto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IServiceBase<TEntity, TModel, TDto, TId> where TEntity : EntityBase<TId> where TModel : ModelBase where TDto : DtoBase
    {
        void Add(TModel model);
        void Delete(TId id);        
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        TDto Get(TId id);
        IEnumerable<TDto> GetList();
        IEnumerable<TDto> GetList(Expression<Func<TEntity, bool>> predicate);
        bool Save();
    }
}
