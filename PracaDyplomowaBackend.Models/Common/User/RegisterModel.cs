using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Models.Common.User
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
    }
}
