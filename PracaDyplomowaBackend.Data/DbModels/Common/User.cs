using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Data.DbModels.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracaDyplomowaBackend.Data.DbModels.Common
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime Added { get; set; }
        public string ConfirmationCode { get; set; }
        public bool Confirmed { get; set; }

        public UserRole UserRole { get; set; }
        public virtual ICollection<UserFriend> Friends { get; set; }
        public virtual ICollection<UserFriend> FriendOf { get; set; }

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
        public ICollection<ReviewRate> ReviewRates { get; set; }
    }
}
