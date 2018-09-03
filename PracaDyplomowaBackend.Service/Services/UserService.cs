﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using CryptoHelper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Role;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;

namespace PracaDyplomowaBackend.Service.Services
{
    public class UserService : ServiceBase<User, RegisterModel, UserDto, Guid>, IUserService
    {
        private new readonly IUserRepository _repository;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenProvider _tokenProvider;

        public UserService(IUserRepository repository, ITokenProvider tokenProvider, IRoleRepository roleRepository) : base(repository)
        {
            _repository = repository;
            _roleRepository = roleRepository;
            _tokenProvider = tokenProvider;
        }

        public bool Authenticate(LoginModel loginModel)
        {
            var user = _repository.Get(loginModel.EmailAddress);

            return Crypto.VerifyHashedPassword(user.Password, loginModel.Password);
        }

        public string CreateToken(LoginModel loginModel)
        {
            var user = Mapper.Map<UserDto>(_repository.Get(loginModel.EmailAddress));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.EmailAddress),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Lastname),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("Role", user.Role)
            };

            return _tokenProvider.BuildToken(claims);
        }

        public void Delete(string emailAddress)
        {
            var user = _repository.Get(emailAddress);

            _repository.Delete(user);
        }

        public UserDto Get(string emailAddress)
        {
            User user = _repository.Get(emailAddress);

            return Mapper.Map<UserDto>(user);
        }        

        public void Register(RegisterModel registerModel)
        {
            User user = Mapper.Map<User>(registerModel);

            user.Password = Crypto.HashPassword(user.Password);

            var userRole = new UserRole { User = user, RoleId = 2 };

            _repository.Add(user);
            _roleRepository.AddUserRole(userRole);
        }        
    }
}
