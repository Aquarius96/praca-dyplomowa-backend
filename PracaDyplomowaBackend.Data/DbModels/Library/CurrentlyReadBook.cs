using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Library
{
    public class CurrentlyReadBook
    {
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        public DateTime Added { get; set; }
    }
}
