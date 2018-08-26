using System;
using System.Linq;
using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Service.Services
{
    public class UserService : ServiceBase<User, RegisterModel, UserDto, Guid>, IUserService
    {
        private new readonly IUserRepository _repository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public void AddCurrentlyReadBook(string userEmailAddress, int bookId)
        {
            var user = _repository.Get(userEmailAddress);

            var currentlyReadBook = new CurrentlyReadBook { User = user, BookId = bookId };

            if (_repository.Exists(dbUser => dbUser.EmailAddress == userEmailAddress && dbUser.WantedBooks.Any(wantedBook => wantedBook.BookId == bookId)))
            {
                DeleteWantedBook(userEmailAddress, bookId);
            }
            
            _repository.AddCurrentlyReadBook(currentlyReadBook);
        }

        public void AddFavoriteBook(string userEmailAddress, int bookId)
        {
            var user = _repository.Get(userEmailAddress);

            var favoriteBook = new FavoriteBook { User = user, BookId = bookId };

            _repository.AddFavoriteBook(favoriteBook);
        }

        public void AddReadBook(string userEmailAddress, int bookId, DateTime finished)
        {
            var user = _repository.Get(userEmailAddress);

            var readBook = new ReadBook { User = user, BookId = bookId, Added = finished };

            if (_repository.Exists(dbUser => dbUser.EmailAddress == userEmailAddress && dbUser.WantedBooks.Any(wantedBook => wantedBook.BookId == bookId)))
            {
                DeleteWantedBook(userEmailAddress, bookId);
            }

            if (_repository.Exists(dbUser => dbUser.EmailAddress == userEmailAddress && dbUser.CurrentlyReadBooks.Any(currentlyReadBook => currentlyReadBook.BookId == bookId)))
            {
                DeleteWantedBook(userEmailAddress, bookId);
            }

            _repository.AddReadBook(readBook);
        }

        public void AddWantedBook(string userEmailAddress, int bookId)
        {
            var user = _repository.Get(userEmailAddress);

            var wantedBook = new WantedBook { User = user, BookId = bookId };

            _repository.AddWantedBook(wantedBook);
        }

        public void DeleteCurrentlyReadBook(string userEmailAddress, int bookId)
        {
            CurrentlyReadBook currentlyReadBook = _repository.GetCurrentlyReadBook(userEmailAddress, bookId);

            _repository.DeleteCurrentlyReadBook(currentlyReadBook);
        }

        public void DeleteFavoriteBook(string userEmailAddress, int bookId)
        {
            FavoriteBook favoriteBook = _repository.GetFavoriteBook(userEmailAddress, bookId);

            _repository.DeleteFavoriteBook(favoriteBook);
        }

        public void DeleteReadBook(string userEmailAddress, int bookId)
        {
            ReadBook readBook = _repository.GetReadBook(userEmailAddress, bookId);

            _repository.DeleteReadbook(readBook);
        }

        public void DeleteWantedBook(string userEmailAddress, int bookId)
        {
            WantedBook wantedBook = _repository.GetWantedBook(userEmailAddress, bookId);

            _repository.DeleteWantedBook(wantedBook);
        }

        public void Register(RegisterModel registerModel)
        {
            var user = Mapper.Map<User>(registerModel);
            _repository.Add(user);
        }        
    }
}
