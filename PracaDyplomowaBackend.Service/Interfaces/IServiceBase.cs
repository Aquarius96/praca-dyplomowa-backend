using PracaDyplomowaBackend.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IServiceBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        bool Save();
    }
}
