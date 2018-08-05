using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Library
{
    public class FavoriteAuthor
    {
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
