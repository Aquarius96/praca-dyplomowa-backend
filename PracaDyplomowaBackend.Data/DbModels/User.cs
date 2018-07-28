using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracaDyplomowaBackend.Data.DbModels
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
    }
}
