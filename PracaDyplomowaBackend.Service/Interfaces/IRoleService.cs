using PracaDyplomowaBackend.Data.DbModels.Role;
using PracaDyplomowaBackend.Models.Models.Role;
using PracaDyplomowaBackend.Models.ModelsDto.Role;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IRoleService : IServiceBase<Role, AddRoleModel, RoleDto, int>
    {        
    }
}
