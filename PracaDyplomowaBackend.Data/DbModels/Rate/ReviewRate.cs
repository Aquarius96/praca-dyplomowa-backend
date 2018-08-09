using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Rate
{
    public class ReviewRate
    {
        [ForeignKey("BookReviewId")]
        public BookReview BookReview { get; set; }
        public int BookReviewId { get; set; }        

        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        public bool Positive { get; set; }
    }
}
