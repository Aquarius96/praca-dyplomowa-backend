using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Role;
using PracaDyplomowaBackend.Models.Models.Role;
using PracaDyplomowaBackend.Models.ModelsDto.Role;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AddRoleModel, Role>();

            CreateMap<Role, RoleDto>();
        }
    }
}
