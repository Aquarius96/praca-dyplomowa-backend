using PracaDyplomowaBackend.Models.ModelsDto.Genre;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Models.ModelsDto.Library
{
    public class BookAuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }

        public IEnumerable<GenreDto> Genres { get; set; }
        public RateDto Rating { get; set; }
    }
}
