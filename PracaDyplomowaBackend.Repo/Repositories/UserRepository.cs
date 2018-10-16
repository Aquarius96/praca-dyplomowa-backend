using Microsoft.EntityFrameworkCore;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Paging;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
using System;
using System.Collections.Generic;
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
            return _context.Users.Where(user => user.EmailAddress == emailAddress).Include(user => user.AuthorComments).Include(user => user.BookComments).Include(user => user.BookReviews).Include(user => user.FavoriteAuthors).Include(user => user.FavoriteBooks).Include(user => user.ReadBooks).Include(user => user.UserRole.Role).FirstOrDefault();
        }
        
        public new IEnumerable<User> GetList(ResourceParameters resourceParameters)
        {
            var entities = _context.Users.Where(entity => resourceParameters.SearchProperties.Any(property => _stringProvider.PropertyContainsQuery(entity.GetType().GetProperty(property).GetValue(entity, null).ToString(), resourceParameters.SearchQuery)))
            .Skip(resourceParameters.PageSize * (resourceParameters.PageNumber - 1))
            .Take(resourceParameters.PageSize)
            .Include(user => user.UserRole.Role);

            return entities;
        }
    }
}
