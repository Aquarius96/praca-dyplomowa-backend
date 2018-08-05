using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Genre
{
    public class BookGenre
    {
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public Guid GenreId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public Guid BookId { get; set; }
    }
}
