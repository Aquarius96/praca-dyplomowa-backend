using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Models.Models.Common.Author
{
    public class AddAuthorModel : ModelBase
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string Gender { get; set; }
    }
}
