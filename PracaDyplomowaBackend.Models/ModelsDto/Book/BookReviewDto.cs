using PracaDyplomowaBackend.Models.ModelsDto.Library;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using System;

namespace PracaDyplomowaBackend.Models.ModelsDto.Book
{
    public class BookReviewDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Added { get; set; }

        public LibraryBookDto Book { get; set; }
        public BookReviewAuthorDto ReviewAuthor { get; set; }
    }
}
