using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using System;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterModel, User>().AfterMap((src, dest) =>
            {
                dest.Added = DateTime.UtcNow;
                dest.Confirmed = false;
            });
            CreateMap<User, UserDto>();            
        }        
    }
}
