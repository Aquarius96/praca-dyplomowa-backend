using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Data.DbModels.Role
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
