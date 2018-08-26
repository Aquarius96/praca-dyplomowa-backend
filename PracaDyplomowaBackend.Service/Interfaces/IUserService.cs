﻿using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using System;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IUserService : IServiceBase<User, RegisterModel, UserDto, Guid>
    {
        void Register(RegisterModel registerModel);

        void AddFavoriteBook(string userEmailAddress, int bookId);
        void AddWantedBook(string userEmailAddress, int bookId);
        void AddCurrentlyReadBook(string userEmailAddress, int bookId);
        void AddReadBook(string userEmailAddress, int bookId, DateTime finished);

        void DeleteFavoriteBook(string userEmailAddress, int bookId);
        void DeleteWantedBook(string userEmailAddress, int bookId);
        void DeleteCurrentlyReadBook(string userEmailAddress, int bookId);
        void DeleteReadBook(string userEmailAddress, int bookId);
    }
}
