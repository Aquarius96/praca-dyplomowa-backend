using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Models.ModelsDto.Library
{
    public class ReadBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PagesCount { get; set; }
        public string PhotoUrl { get; set; }
        public bool Confirmed { get; set; }
        public string Released { get; set; }
        public DateTime Finished { get; set; }

        public RateDto Rating { get; set; }

        public IEnumerable<BookGenreDto> Genres { get; set; }
        public IEnumerable<BookAuthorDto> Authors { get; set; }        
    }
}
