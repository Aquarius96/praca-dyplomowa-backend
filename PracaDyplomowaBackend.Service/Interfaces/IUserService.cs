using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using System;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IUserService : IServiceBase<User, RegisterModel, UserDto, Guid>
    {
        void Register(RegisterModel registerModel);
        bool Authenticate(LoginModel loginModel);
        string CreateToken(LoginModel loginModel);
        void AddImage(string userEmailAddress, string imageUrl);

        void Delete(string emailAddress);

        void Update(string emailAddress, UpdateModel updateModel);
        bool ChangePassword(string emailAddress, ChangePasswordModel changePasswordModel);

        UserDto Get(string emailAddress);
    }
}
