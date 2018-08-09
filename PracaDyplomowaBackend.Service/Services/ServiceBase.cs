using PracaDyplomowaBackend.Data.DbModels;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;
using System;

namespace PracaDyplomowaBackend.Service.Services
{
    public abstract class ServiceBase<TEntity, TId> : IServiceBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        protected readonly IRepositoryBase<TEntity, TId> _repository;

        protected ServiceBase(IRepositoryBase<TEntity, TId> repository)
        {
            _repository = repository;
        }
        public bool Save()
        {
            return _repository.Save();
        }
    }
}
