using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Models.ModelsDto.Genre;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IGenreRepository : IRepositoryBase<Genre, int>
    {
        void AddAuthorGenre(AuthorGenre authorGenre);
        void AddBookGenre(BookGenre bookGenre);

        AuthorGenre GetAuthorGenre(int authorId, int genreId);
        BookGenre GetBookGenre(int bookId, int genreId);

        IEnumerable<GenreDto> GetAuthorGenres(int authorId);
        IEnumerable<GenreDto> GetBookGenres(int bookId);

        void DeleteAuthorGenre(AuthorGenre authorGenre);
        void DeleteBookGenre(BookGenre bookGenre);
    }
}
