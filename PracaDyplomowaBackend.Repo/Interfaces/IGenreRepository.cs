using PracaDyplomowaBackend.Data.DbModels.Genre;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IGenreRepository : IRepositoryBase<Genre, int>
    {
        void AddAuthorGenre(AuthorGenre authorGenre);
        void AddBookGenre(BookGenre bookGenre);

        AuthorGenre GetAuthorGenre(int authorId, int genreId);
        BookGenre GetBookGenre(int bookId, int genreId);

        void RemoveAuthorGenre(AuthorGenre authorGenre);
        void RemoveBookGenre(BookGenre bookGenre);
    }
}
