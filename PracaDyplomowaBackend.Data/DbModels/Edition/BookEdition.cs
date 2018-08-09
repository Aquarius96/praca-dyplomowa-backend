using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Edition
{
    public class BookEdition : EntityBase<int>
    {        
        public DateTime Added { get; set; }
        public DateTime Released { get; set; }
        public string PhotoUrl { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }

        [ForeignKey("PublishingHouseId")]
        public PublishingHouse PublishingHouse { get; set; }
        public int PublishingHouseId { get; set; }
        
        public ICollection<BookEditionTranslator> BookEditionTranslators { get; set; }
    }
}
