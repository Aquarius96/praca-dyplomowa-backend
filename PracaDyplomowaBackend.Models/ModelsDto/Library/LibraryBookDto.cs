using System.Collections.Generic;

namespace PracaDyplomowaBackend.Models.ModelsDto.Library
{
    public class LibraryBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<BookGenreDto> Genres { get; set; }
        public IEnumerable<BookAuthorDto> Authors { get; set; }
    }
}
