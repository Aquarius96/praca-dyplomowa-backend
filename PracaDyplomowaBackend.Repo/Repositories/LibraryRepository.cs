using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
using System;
using System.Linq;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class LibraryRepository : RepositoryBase<User, Guid>, ILibraryRepository
    {
        public LibraryRepository(DataContext context, IStringProvider stringProvider) : base(context, stringProvider)
        {
        }

        public void AddCurrentlyReadBook(CurrentlyReadBook currentlyReadBook)
        {
            _context.CurrentlyReadBooks.Add(currentlyReadBook);
        }

        public void AddFavoriteAuthor(FavoriteAuthor favoriteAuthor)
        {
            _context.FavoriteAuthors.Add(favoriteAuthor);
        }

        public void AddFavoriteBook(FavoriteBook favoriteBook)
        {
            _context.FavoriteBooks.Add(favoriteBook);
        }

        public void AddReadBook(ReadBook readBook)
        {
            _context.ReadBooks.Add(readBook);
        }

        public void AddWantedBook(WantedBook wantedBook)
        {
            _context.WantedBooks.Add(wantedBook);
        }

        public void DeleteCurrentlyReadBook(CurrentlyReadBook currentlyReadBook)
        {
            _context.CurrentlyReadBooks.Remove(currentlyReadBook);
        }

        public void DeleteFavoriteAuthor(FavoriteAuthor favoriteAuthor)
        {
            _context.FavoriteAuthors.Remove(favoriteAuthor);
        }

        public void DeleteFavoriteBook(FavoriteBook favoriteBook)
        {
            _context.FavoriteBooks.Remove(favoriteBook);
        }

        public void DeleteReadbook(ReadBook readBook)
        {
            _context.ReadBooks.Remove(readBook);
        }

        public void DeleteWantedBook(WantedBook wantedBook)
        {
            _context.WantedBooks.Remove(wantedBook);
        }

        public CurrentlyReadBook GetCurrentlyReadBook(string userEmailAddress, int bookId)
        {
            return _context.CurrentlyReadBooks.FirstOrDefault(currentlyReadBook => currentlyReadBook.User.EmailAddress == userEmailAddress && currentlyReadBook.BookId == bookId);
        }

        public FavoriteAuthor GetFavoriteAuthor(string userEmailAddress, int authorId)
        {
            return _context.FavoriteAuthors.FirstOrDefault(favoriteAuthor => favoriteAuthor.User.EmailAddress == userEmailAddress && favoriteAuthor.AuthorId == authorId);
        }

        public FavoriteBook GetFavoriteBook(string userEmailAddress, int bookId)
        {
            return _context.FavoriteBooks.FirstOrDefault(favoriteBook => favoriteBook.User.EmailAddress == userEmailAddress && favoriteBook.BookId == bookId);
        }

        public ReadBook GetReadBook(string userEmailAddress, int bookId)
        {
            return _context.ReadBooks.FirstOrDefault(readBook => readBook.User.EmailAddress == userEmailAddress && readBook.BookId == bookId);
        }

        public WantedBook GetWantedBook(string userEmailAddress, int bookId)
        {
            return _context.WantedBooks.FirstOrDefault(wantedBook => wantedBook.User.EmailAddress == userEmailAddress && wantedBook.BookId == bookId);
        }
    }
}
