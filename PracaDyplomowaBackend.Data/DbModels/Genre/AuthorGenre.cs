using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Genre
{
    public class AuthorGenre
    {
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public Guid GenreId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
