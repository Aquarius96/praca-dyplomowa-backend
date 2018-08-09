using PracaDyplomowaBackend.Data.DbModels.Edition;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracaDyplomowaBackend.Data.DbModels.Common
{
    public class PublishingHouse : EntityBase<int>
    {        
        public string Name { get; set; }
        public string Description { get; set; }        
        public string PhotoUrl { get; set; }
        public DateTime Added { get; set; }
        public DateTime Created { get; set; }

        public ICollection<BookEdition> BookEditions { get; set; }
    }
}
