using PracaDyplomowaBackend.Data.DbModels.Common;
using System;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        User Get(string emailAddress);
    }
}
