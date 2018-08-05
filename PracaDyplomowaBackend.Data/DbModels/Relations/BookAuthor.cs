using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Relations
{
    public class BookAuthor
    {
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public Guid BookId { get; set; }
    }
}
