using System.Collections.Generic;

namespace PracaDyplomowaBackend.Utilities.Paging
{
    public class UserResourceParameters : ResourceParameters
    {
        public UserResourceParameters()
        {
            SearchProperties = new List<string> { "Firstname", "Lastname" };
        }
    }
}
