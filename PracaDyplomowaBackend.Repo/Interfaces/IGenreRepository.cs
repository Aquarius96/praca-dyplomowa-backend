using PracaDyplomowaBackend.Data.DbModels.Genre;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IGenreRepository : IRepositoryBase<Genre, int>
    {
        void AddAuthorGenre(AuthorGenre authorGenre);
        void AddBookGenre(BookGenre bookGenre);
    }
}
