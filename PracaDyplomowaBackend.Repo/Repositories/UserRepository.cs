using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
using System;
using System.Linq;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
    {
        public UserRepository(DataContext context, IStringProvider stringProvider) : base(context, stringProvider)
        {
        }

        public User Get(string emailAddress)
        {
            return _context.Users.FirstOrDefault(user => user.EmailAddress == emailAddress);
        }
    }
}
