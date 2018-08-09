﻿using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using System;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IUserService : IServiceBase<User, RegisterModel, UserDto, Guid>
    {
        void Register(RegisterModel registerModel);
    }
}
