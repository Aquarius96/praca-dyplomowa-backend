using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Data.DbModels.Common
{
    public class Book : EntityBase<int>
    {        
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Description { get; set; }        
        public int PagesCount { get; set; }
        public DateTime Released { get; set; }
        public DateTime Added { get; set; }
        public string PhotoUrl { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookRate> BookRates { get; set; }
        public ICollection<BookReview> BookReviews { get; set; }
        public ICollection<BookComment> BookComments { get; set; }
        public ICollection<ReadBook> ReadBooks { get; set; }
        public ICollection<CurrentlyReadBook> CurrentlyReadBooks { get; set; }
        public ICollection<FavoriteBook> FavoriteBooks { get; set; }
        public ICollection<WantedBook> WantedBooks { get; set; }
    }
}
