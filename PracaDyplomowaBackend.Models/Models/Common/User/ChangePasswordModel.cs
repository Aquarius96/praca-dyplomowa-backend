using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Models.Models.Common.User
{
    public class ChangePasswordModel : ModelBase
    {
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
