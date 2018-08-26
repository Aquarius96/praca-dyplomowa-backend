using System;
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

        public void AddFavoriteBook(string userEmailAddress, int bookId)
        {
            var user = _repository.Get(userEmailAddress);

            var favoriteBook = new FavoriteBook { User = user, BookId = bookId };

            _repository.AddFavoriteBook(favoriteBook);
        }

        public void DeleteFavoriteBook(string userEmailAddress, int bookId)
        {
            FavoriteBook favoriteBook = _repository.GetFavoriteBook(userEmailAddress, bookId);

            _repository.DeleteFavoriteBook(favoriteBook);
        }

        public void Register(RegisterModel registerModel)
        {
            var user = Mapper.Map<User>(registerModel);
            _repository.Add(user);
        }        
    }
}
