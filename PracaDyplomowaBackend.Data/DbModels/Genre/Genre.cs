using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Data.DbModels.Genre
{
    public class Genre : EntityBase<int>
    {
       public string GenreName { get; set; }

        public ICollection<AuthorGenre> AuthorGenres { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
