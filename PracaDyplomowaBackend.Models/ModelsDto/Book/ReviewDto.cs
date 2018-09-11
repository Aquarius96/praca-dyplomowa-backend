using PracaDyplomowaBackend.Models.ModelsDto.Library;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using System;

namespace PracaDyplomowaBackend.Models.ModelsDto.Book
{
    public class ReviewDto : DtoBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Added { get; set; }

        public RateDto Rating { get; set; }

        public LibraryBookDto Book { get; set; }
        public BookReviewAuthorDto ReviewAuthor { get; set; }
    }
}
