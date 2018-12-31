using PracaDyplomowaBackend.Models.ModelsDto.Rate;

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

        public RateDto Rating { get; set; }
    }
}
