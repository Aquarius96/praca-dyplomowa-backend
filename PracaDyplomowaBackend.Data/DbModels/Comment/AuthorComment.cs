using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Comment
{
    public class AuthorComment : EntityBase<int>
    {                
        public string Content { get; set; }
        public DateTime Added { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("UserId")]        
        public User User { get; set; }
        public Guid UserId { get; set; }          
    }
}
