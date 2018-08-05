using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Library
{
    public class FavoriteBook
    {
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public Guid BookId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
