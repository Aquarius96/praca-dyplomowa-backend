using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Utilities.Paging
{
    public class BookResourceParameters : ResourceParameters
    {
        public BookResourceParameters()
        {
            SearchProperties = new List<string> { "Title", "OriginalTitle" };
        }
    }
}
