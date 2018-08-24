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

        public void AddAuthorGenre(AuthorGenre authorGenre)
        {
            _context.AuthorGenres.Add(authorGenre);
        }

        public void AddBookGenre(BookGenre bookGenre)
        {
            _context.BookGenres.Add(bookGenre);
        }
    }
}
