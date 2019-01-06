using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;
using System;
using System.Linq;

namespace PracaDyplomowaBackend.Service.Services
{
    public class LibraryService : ServiceBase<User, RegisterModel, UserDto, Guid>, ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IUserRepository _userRepository;     

        public LibraryService(ILibraryRepository libraryRepository, IAuthorRepository authorRepository, IBookRepository bookRepository, IGenreRepository genreRepository, IUserRepository userRepository) : base(userRepository)
        {
            _libraryRepository = libraryRepository;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _userRepository = userRepository;
        }

        public void AddCurrentlyReadBook(string userEmailAddress, int bookId)
        {
            User user = _userRepository.Get(userEmailAddress);

            var currentlyReadBook = new CurrentlyReadBook { User = user, BookId = bookId };

            if (_userRepository.Exists(dbUser => dbUser.EmailAddress == userEmailAddress && dbUser.WantedBooks.Any(wantedBook => wantedBook.BookId == bookId)))
            {
                DeleteWantedBook(userEmailAddress, bookId);
            }

            if(_userRepository.Exists(dbUser => dbUser.EmailAddress == userEmailAddress && dbUser.ReadBooks.Any(readBook => readBook.BookId == bookId)))
            {
                DeleteReadBook(userEmailAddress, bookId);
            }

            _libraryRepository.AddCurrentlyReadBook(currentlyReadBook);
        }

        public void AddFavoriteAuthor(string userEmailAddress, int authorId)
        {
            User user = _userRepository.Get(userEmailAddress);

            var favoriteAuthor = new FavoriteAuthor { User = user, AuthorId = authorId };

            _libraryRepository.AddFavoriteAuthor(favoriteAuthor);
        }

        public void AddFavoriteBook(string userEmailAddress, int bookId)
        {
            User user = _userRepository.Get(userEmailAddress);

            var favoriteBook = new FavoriteBook { User = user, BookId = bookId };

            _libraryRepository.AddFavoriteBook(favoriteBook);
        }

        public void AddReadBook(string userEmailAddress, int bookId, DateTime finished)
        {
            User user = _userRepository.Get(userEmailAddress);

            var readBook = new ReadBook { User = user, BookId = bookId, Finished = finished };

            if (_userRepository.Exists(dbUser => dbUser.EmailAddress == userEmailAddress && dbUser.WantedBooks.Any(wantedBook => wantedBook.BookId == bookId)))
            {
                DeleteWantedBook(userEmailAddress, bookId);
            }

            if (_userRepository.Exists(dbUser => dbUser.EmailAddress == userEmailAddress && dbUser.CurrentlyReadBooks.Any(currentlyReadBook => currentlyReadBook.BookId == bookId)))
            {
                DeleteCurrentlyReadBook(userEmailAddress, bookId);
            }

            _libraryRepository.AddReadBook(readBook);
        }

        public void AddWantedBook(string userEmailAddress, int bookId)
        {
            User user = _userRepository.Get(userEmailAddress);

            var wantedBook = new WantedBook { User = user, BookId = bookId };

            if (_userRepository.Exists(dbUser => dbUser.EmailAddress == userEmailAddress && dbUser.CurrentlyReadBooks.Any(currentlyReadBook => currentlyReadBook.BookId == bookId)))
            {
                DeleteCurrentlyReadBook(userEmailAddress, bookId);
            }

            if (_userRepository.Exists(dbUser => dbUser.EmailAddress == userEmailAddress && dbUser.ReadBooks.Any(readBook => readBook.BookId == bookId)))
            {
                DeleteReadBook(userEmailAddress, bookId);
            }

            _libraryRepository.AddWantedBook(wantedBook);
        }

        public void DeleteCurrentlyReadBook(string userEmailAddress, int bookId)
        {
            CurrentlyReadBook currentlyReadBook = _libraryRepository.GetCurrentlyReadBook(userEmailAddress, bookId);

            _libraryRepository.DeleteCurrentlyReadBook(currentlyReadBook);
        }

        public void DeleteFavoriteAuthor(string userEmailAddress, int authorId)
        {
            FavoriteAuthor favoriteAuthor = _libraryRepository.GetFavoriteAuthor(userEmailAddress, authorId);

            _libraryRepository.DeleteFavoriteAuthor(favoriteAuthor);
        }

        public void DeleteFavoriteBook(string userEmailAddress, int bookId)
        {
            FavoriteBook favoriteBook = _libraryRepository.GetFavoriteBook(userEmailAddress, bookId);

            _libraryRepository.DeleteFavoriteBook(favoriteBook);
        }

        public void DeleteReadBook(string userEmailAddress, int bookId)
        {
            ReadBook readBook = _libraryRepository.GetReadBook(userEmailAddress, bookId);

            _libraryRepository.DeleteReadbook(readBook);
        }

        public void DeleteWantedBook(string userEmailAddress, int bookId)
        {
            WantedBook wantedBook = _libraryRepository.GetWantedBook(userEmailAddress, bookId);

            _libraryRepository.DeleteWantedBook(wantedBook);
        }

        public LibraryDto GetUserLibrary(string userEmailAddress)
        {
            var library = new LibraryDto
            {
                CurrentlyReadBooks = _libraryRepository.GetUserCurrentlyReadBooks(userEmailAddress),
                FavoriteAuthors = _libraryRepository.GetUserFavoriteAuthors(userEmailAddress),
                FavoriteBooks = _libraryRepository.GetUserFavoriteBooks(userEmailAddress),
                ReadBooks = _libraryRepository.GetUserReadBooks(userEmailAddress),
                WantedBooks = _libraryRepository.GetUserWantedBooks(userEmailAddress),
                BookRates = _libraryRepository.GetUserBookRates(userEmailAddress),
                AuthorRates = _libraryRepository.GetUserAuthorRates(userEmailAddress),
                ReviewRates = _libraryRepository.GetUserReviewRates(userEmailAddress)
            };

            foreach(var book in library.CurrentlyReadBooks)
            {
                book.Rating = _bookRepository.GetBookRating(book.Id);
            }

            foreach (var book in library.FavoriteBooks)
            {
                book.Rating = _bookRepository.GetBookRating(book.Id);
            }

            foreach (var book in library.ReadBooks)
            {
                book.Rating = _bookRepository.GetBookRating(book.Id);
            }

            foreach (var book in library.WantedBooks)
            {
                book.Rating = _bookRepository.GetBookRating(book.Id);
            }

            foreach (var author in library.FavoriteAuthors)
            {
                author.Rating = _authorRepository.GetAuthorRating(author.Id);
                author.Genres = _genreRepository.GetAuthorGenres(author.Id);
            }

            return library;
        }
    }
}
