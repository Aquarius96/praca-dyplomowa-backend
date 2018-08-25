using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Relations;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IAuthorRepository : IRepositoryBase<Author, int>
    {
        void AddBookAuthor(BookAuthor bookAuthor);
        void AddAuthorComment(AuthorComment authorComment);

        void DeleteAuthorComment(AuthorComment authorComment);

        AuthorComment GetAuthorComment(int id);
    }
}
