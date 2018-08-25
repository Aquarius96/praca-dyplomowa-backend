using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Models.ModelsDto.Genre;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
using System.Collections.Generic;
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

        public IEnumerable<GenreDto> GetAuthorGenres(int authorId)
        {
            var authorGenres = _context.Authors.Where(author => author.Id == authorId).SelectMany(author => author.AuthorGenres).Select(authorGenre => authorGenre.Genre);

            return Mapper.Map<IEnumerable<GenreDto>>(authorGenres);
        }

        public BookGenre GetBookGenre(int bookId, int genreId)
        {
            return _context.BookGenres.FirstOrDefault(bookGenre => bookGenre.BookId == bookId && bookGenre.GenreId == genreId);
        }

        public IEnumerable<GenreDto> GetBookGenres(int bookId)
        {
            var bookGenres = _context.Books.Where(book => book.Id == bookId).SelectMany(book => book.BookGenres).Select(bookGenre => bookGenre.Genre);

            return Mapper.Map<IEnumerable<GenreDto>>(bookGenres);
        }

        public void DeleteAuthorGenre(AuthorGenre authorGenre)
        {
            _context.AuthorGenres.Remove(authorGenre);
        }

        public void DeleteBookGenre(BookGenre bookGenre)
        {
            _context.BookGenres.Remove(bookGenre);
        }
    }
}
