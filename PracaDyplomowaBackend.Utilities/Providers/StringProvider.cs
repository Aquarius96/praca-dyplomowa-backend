using PracaDyplomowaBackend.Utilities.Providers.Interfaces;

namespace PracaDyplomowaBackend.Utilities.Providers
{
    public class StringProvider : IStringProvider
    {
        public bool PropertyContainsQuery(string property, string query)
        {
            return property.Trim().ToLowerInvariant().Contains(query.Trim().ToLowerInvariant());
        }

        public bool CompareCaseInsensitive(string first, string second)
        {
            return first.Trim().ToLowerInvariant() == second.Trim().ToLowerInvariant();
        }
    }
}
