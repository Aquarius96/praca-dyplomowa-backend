using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Comment
{
    public class BookComment
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Added { get; set; }

        [ForeignKey("BookId")]        
        public Book Book { get; set; }
        public Guid BookId { get; set; }

        [ForeignKey("UserId")]        
        public User User { get; set; }
        public Guid UserId { get; set; }       
    }
}
