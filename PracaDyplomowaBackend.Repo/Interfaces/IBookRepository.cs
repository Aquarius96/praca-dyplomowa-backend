using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book, int>
    {
        void AddBookComment(BookComment bookComment);

        void DeleteBookComment(BookComment bookComment);

        BookComment GetBookComment(int id);
    }
}
