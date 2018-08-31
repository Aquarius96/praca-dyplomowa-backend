using PracaDyplomowaBackend.Data.DbModels.Role;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IRoleRepository : IRepositoryBase<Role, int>
    {
        void AddUserRole(UserRole userRole);
    }
}
