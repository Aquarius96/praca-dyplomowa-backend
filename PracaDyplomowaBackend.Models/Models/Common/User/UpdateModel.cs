using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Models.Models.Common.User
{
    public class UpdateModel : ModelBase
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
