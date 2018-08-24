using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Utilities.Paging
{
    public class AuthorResourceParameters : ResourceParameters 
    {
        public AuthorResourceParameters()
        {
            SearchProperties = new List<string> { "Firstname", "Lastname" };
        }
    }
}
