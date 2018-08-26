using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Library;
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

        public void AddFavoriteBook(FavoriteBook favoriteBook)
        {
            _context.FavoriteBooks.Add(favoriteBook);
        }

        public void DeleteFavoriteBook(FavoriteBook favoriteBook)
        {
            _context.FavoriteBooks.Remove(favoriteBook);
        }

        public User Get(string emailAddress)
        {
            return _context.Users.FirstOrDefault(user => user.EmailAddress == emailAddress);
        }

        public FavoriteBook GetFavoriteBook(string userEmailAddress, int bookId)
        {
            return _context.FavoriteBooks.FirstOrDefault(favoriteBook => favoriteBook.User.EmailAddress == userEmailAddress && favoriteBook.BookId == bookId);
        }
    }
}
