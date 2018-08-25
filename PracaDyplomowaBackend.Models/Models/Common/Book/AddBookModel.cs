using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Models.Models.Common.Book
{
    public class AddBookModel : ModelBase
    {
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Description { get; set; }
        public int PagesCount { get; set; }
        public DateTime Released { get; set; }        

        public ICollection<int> GenreIds { get; set; }
        public ICollection<int> AuthorIds { get; set; }
    }
}
