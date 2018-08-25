using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Models.ModelsDto.Book
{
    public class BookDto : DtoBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Description { get; set; }
        public int PagesCount { get; set; }
        public DateTime Released { get; set; }
        public DateTime Added { get; set; }
    }
}
