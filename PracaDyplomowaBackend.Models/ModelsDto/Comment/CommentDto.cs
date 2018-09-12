using System;

namespace PracaDyplomowaBackend.Models.ModelsDto.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }        
        public string Content { get; set; }
        public DateTime Added { get; set; }

        public CommentAuthorDto Author { get; set; }
    }
}
