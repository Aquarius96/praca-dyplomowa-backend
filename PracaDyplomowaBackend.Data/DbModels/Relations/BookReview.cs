using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Relations
{
    public class BookReview : EntityBase<int>
    {
        [ForeignKey("BookId")]        
        public Book Book { get; set; }
        public int BookId { get; set; }

        [ForeignKey("UserId")]        
        public User User { get; set; }
        public Guid UserId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Added { get; set; }
        
        public ICollection<ReviewRate> ReviewRates { get; set; }
    }
}
