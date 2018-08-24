namespace PracaDyplomowaBackend.Utilities.Providers.Interfaces
{
    public interface IStringProvider
    {
        bool PropertyContainsQuery(string property, string query);
        bool CompareCaseInsensitive(string first, string second);
    }
}
