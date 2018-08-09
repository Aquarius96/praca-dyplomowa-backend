using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class UserRepository : RepositoryBase<User, Guid>
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
