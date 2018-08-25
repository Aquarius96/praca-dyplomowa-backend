using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels;
using PracaDyplomowaBackend.Models.Models;
using PracaDyplomowaBackend.Models.ModelsDto;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PracaDyplomowaBackend.Service.Services
{
    public abstract class ServiceBase<TEntity, TModel, TDto, TId> : IServiceBase<TEntity, TModel, TDto, TId> where TEntity : EntityBase<TId> where TModel : ModelBase where TDto : DtoBase
    {
        protected readonly IRepositoryBase<TEntity, TId> _repository;

        protected ServiceBase(IRepositoryBase<TEntity, TId> repository)
        {
            _repository = repository;
        }

        public void Add(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            _repository.Add(entity);
        }

        public void Delete(TId id)
        {
            var entity = _repository.Get(id);
            _repository.Delete(entity);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Exists(predicate);
        }

        public TDto Get(TId id)
        {
            var entity = _repository.Get(id);
            return Mapper.Map<TDto>(entity);
        }

        public IEnumerable<TDto> GetList()
        {
            var entities = _repository.GetList();
            return Mapper.Map<IEnumerable<TDto>>(entities);
        }

        public IEnumerable<TDto> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _repository.GetList(predicate);
            return Mapper.Map<IEnumerable<TDto>>(entities);
        }

        public IEnumerable<TDto> GetList(ResourceParameters resourceParameters)
        {
            var entities = _repository.GetList(resourceParameters);
            return Mapper.Map<IEnumerable<TDto>>(entities);
        }

        public bool ListExists(IEnumerable<TId> ids)
        {
            return _repository.ListExists(ids);
        }

        public bool Save()
        {
            return _repository.Save();
        }
    }
}
