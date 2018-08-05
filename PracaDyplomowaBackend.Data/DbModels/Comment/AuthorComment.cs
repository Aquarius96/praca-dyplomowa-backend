using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Comment
{
    public class AuthorComment
    {        
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Added { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }

        [ForeignKey("UserId")]        
        public User User { get; set; }
        public Guid UserId { get; set; }          
    }
}
