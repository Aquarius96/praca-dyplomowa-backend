using PracaDyplomowaBackend.Data.DbModels.Role;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class RoleRepository : RepositoryBase<Role, int>, IRoleRepository
    {
        public RoleRepository(DataContext context, IStringProvider stringProvider) : base(context, stringProvider)
        {
        }

        public void AddUserRole(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
        }
    }
}
