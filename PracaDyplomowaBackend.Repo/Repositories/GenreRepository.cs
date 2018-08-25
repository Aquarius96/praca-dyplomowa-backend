using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
using System.Linq;

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

        public AuthorGenre GetAuthorGenre(int authorId, int genreId)
        {
            return _context.AuthorGenres.FirstOrDefault(authorGenre => authorGenre.AuthorId == authorId && authorGenre.GenreId == genreId);
        }

        public BookGenre GetBookGenre(int bookId, int genreId)
        {
            return _context.BookGenres.FirstOrDefault(bookGenre => bookGenre.BookId == bookId && bookGenre.GenreId == genreId);
        }

        public void RemoveAuthorGenre(AuthorGenre authorGenre)
        {
            _context.AuthorGenres.Remove(authorGenre);
        }

        public void RemoveBookGenre(BookGenre bookGenre)
        {
            _context.BookGenres.Remove(bookGenre);
        }
    }
}
