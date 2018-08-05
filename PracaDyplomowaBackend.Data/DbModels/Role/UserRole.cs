using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Role
{
    public class UserRole
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
        
        [ForeignKey("RoleId")]        
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
