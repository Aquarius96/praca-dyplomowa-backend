using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class GenreRepository : RepositoryBase<Genre, int>, IGenreRepository
    {
        public GenreRepository(DataContext context, IStringProvider stringProvider) : base(context, stringProvider)
        {
        }
    }
}
