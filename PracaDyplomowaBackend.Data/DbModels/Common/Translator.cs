using PracaDyplomowaBackend.Data.DbModels.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracaDyplomowaBackend.Data.DbModels.Common
{
    public class Translator : EntityBase<int>
    {        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }        
        public string Gender { get; set; }

        public ICollection<BookEditionTranslator> BookEditionTranslators { get; set; }
    }
}
