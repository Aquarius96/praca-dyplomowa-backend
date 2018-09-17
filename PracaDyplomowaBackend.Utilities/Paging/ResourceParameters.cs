using System.Collections.Generic;

namespace PracaDyplomowaBackend.Utilities.Paging
{
    public abstract class ResourceParameters
    {
        protected virtual int maxPageSize { get; set; } = 100;

        public virtual int PageNumber { get; set; } = 1;

        protected virtual int _pageSize { get; set; } = 10;

        public int PageSize { get => _pageSize; set => _pageSize = (value > maxPageSize || value < 1) ? maxPageSize : value; }

        public string SearchQuery { get; set; } = "";

        public string SortField { get; set; } = "Id";

        public bool SortAscending { get; set; } = true;

        public List<string> SearchProperties;
    }
}
