using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Utilities
{
    public class ResourceParameters
    {
        const int maxPageSize = 100;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize { get => _pageSize; set => _pageSize = (value > maxPageSize) ? maxPageSize : value; }

        public string SearchQuery { get; set; } = "";
    }
}
