using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Repo.Interfaces;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class BookRepository : RepositoryBase<Book, int>, IBookRepository
    {
        public BookRepository(DataContext context) : base(context)
        {
        }
    }
}
