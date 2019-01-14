using System;

namespace PracaDyplomowaBackend.Models.ModelsDto.User
{
    public class UserDto : DtoBase
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }        
        public DateTime Added { get; set; }
        public string Role { get; set; }

        public int ReadBooksAmount { get; set; }
        public int FavoriteBooksAmount { get; set; }
        public int AddedReviewsAmount { get; set; }
        public int AddedCommentsAmount { get; set; }
        public int FavoriteAuthorsAmount { get; set; }
    }
}
