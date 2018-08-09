using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
    }
}
