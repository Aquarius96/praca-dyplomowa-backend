using System.Collections.Generic;

namespace PracaDyplomowaBackend.Models.ModelsDto.Library
{
    public class LibraryDto
    {
        public IEnumerable<LibraryBookDto> CurrentlyReadBooks { get; set; }
        public IEnumerable<LibraryBookDto> FavoriteBooks { get; set; }
        public IEnumerable<ReadBookDto> ReadBooks { get; set; }
        public IEnumerable<LibraryBookDto> WantedBooks { get; set; }
        public IEnumerable<BookAuthorDto> FavoriteAuthors { get; set; }
        public IEnumerable<BookRateDto> BookRates { get; set; }
        public IEnumerable<AuthorRateDto> AuthorRates { get; set; }
        public IEnumerable<ReviewRateDto> ReviewRates { get; set; }
    }
}
