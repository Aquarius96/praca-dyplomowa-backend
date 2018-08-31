﻿using System.Collections.Generic;

namespace PracaDyplomowaBackend.Data.DbModels.Role
{
    public class Role : EntityBase<int>
    {        
        public string RoleName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
