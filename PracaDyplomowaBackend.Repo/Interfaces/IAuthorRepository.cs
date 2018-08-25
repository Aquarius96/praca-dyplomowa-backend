using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Relations;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IAuthorRepository : IRepositoryBase<Author, int>
    {
        void AddBookAuthor(BookAuthor bookAuthor);
    }
}
