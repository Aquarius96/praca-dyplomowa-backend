using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Data.DbModels.Role;
using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Data.DbModels.Common
{
    public class User : EntityBase<Guid>
    {        
        public string Username { get; set; }
        public string EmailAddress { get; set; }       
        public string Password { get; set; }        
        public string PhotoUrl { get; set; }        

        public UserRole UserRole { get; set; }

        public ICollection<ReadBook> ReadBooks { get; set; }
        public ICollection<CurrentlyReadBook> CurrentlyReadBooks { get; set; }
        public ICollection<FavoriteBook> FavoriteBooks { get; set; }
        public ICollection<WantedBook> WantedBooks { get; set; }
        public ICollection<BookComment> BookComments { get; set; }
        public ICollection<BookRate> BookRates { get; set; }

        public ICollection<FavoriteAuthor> FavoriteAuthors { get; set; }
        public ICollection<AuthorComment> AuthorComments { get; set; }
        public ICollection<AuthorRate> AuthorRates { get; set; }

        public ICollection<BookReview> BookReviews { get; set; }
        public ICollection<BookReviewRate> ReviewRates { get; set; }
    }
}
