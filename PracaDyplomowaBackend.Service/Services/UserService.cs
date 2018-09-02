using System;
using System.Linq;
using AutoMapper;
using CryptoHelper;
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

        public void Register(RegisterModel registerModel)
        {
            User user = Mapper.Map<User>(registerModel);

            user.Password = Crypto.HashPassword(user.Password);

            _repository.Add(user);
        }        
    }
}
