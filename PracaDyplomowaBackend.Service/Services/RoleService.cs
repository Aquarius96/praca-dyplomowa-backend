using PracaDyplomowaBackend.Data.DbModels.Role;
using PracaDyplomowaBackend.Models.Models.Role;
using PracaDyplomowaBackend.Models.ModelsDto.Role;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Service.Services
{
    public class RoleService : ServiceBase<Role, AddRoleModel, RoleDto, int>, IRoleService
    {
        public RoleService(IRoleRepository repository) : base(repository)
        {
        }        
    }
}
