using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Common.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IUserService : IServiceBase<User, Guid>
    {
        void Register(RegisterModel registerModel);
    }
}
