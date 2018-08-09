using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
