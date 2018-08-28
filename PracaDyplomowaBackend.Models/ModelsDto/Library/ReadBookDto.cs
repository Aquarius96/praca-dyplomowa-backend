using System;

namespace PracaDyplomowaBackend.Models.ModelsDto.Library
{
    public class ReadBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Finished { get; set; }
    }
}
