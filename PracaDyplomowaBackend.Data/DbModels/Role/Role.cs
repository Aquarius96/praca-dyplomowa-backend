using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Data.DbModels.Role
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
