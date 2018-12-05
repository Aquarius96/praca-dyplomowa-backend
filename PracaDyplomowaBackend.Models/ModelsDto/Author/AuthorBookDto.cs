using PracaDyplomowaBackend.Models.ModelsDto.Library;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Models.ModelsDto.Author
{
    public class AuthorBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime Released { get; set; }

        public RateDto Rating { get; set; }

        public IEnumerable<BookGenreDto> Genres { get; set; }
        public IEnumerable<BookAuthorDto> Authors { get; set; }
    }
}
