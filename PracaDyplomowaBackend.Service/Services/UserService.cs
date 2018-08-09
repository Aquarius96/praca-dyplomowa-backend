using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Common.User;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Service.Services
{
    public class UserService : ServiceBase<User, Guid>, IUserService
    {        
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public void Register(RegisterModel registerModel)
        {
            var user = Mapper.Map<User>(registerModel);
            _repository.Add(user);
        }
    }
}
