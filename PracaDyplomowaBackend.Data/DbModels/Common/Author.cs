using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Data.DbModels.Common
{
    public class Author : EntityBase<int>
    {        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }

        public ICollection<AuthorGenre> AuthorGenres { get; set; }
        public ICollection<AuthorComment> AuthorComments { get; set; }
        public ICollection<FavoriteAuthor> FavoriteAuthors { get; set; }
        public ICollection<AuthorRate> AuthorRates { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
