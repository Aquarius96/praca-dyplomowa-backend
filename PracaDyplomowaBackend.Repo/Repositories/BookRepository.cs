using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
using System.Linq;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class BookRepository : RepositoryBase<Book, int>, IBookRepository
    {
        public BookRepository(DataContext context, IStringProvider stringProvider) : base(context, stringProvider)
        {
        }

        public void AddBookComment(BookComment bookComment)
        {
            _context.BookComments.Add(bookComment);
        }

        public void DeleteBookComment(BookComment bookComment)
        {
            _context.BookComments.Remove(bookComment);
        }

        public BookComment GetBookComment(int id)
        {
            return _context.BookComments.FirstOrDefault(bookComment => bookComment.Id == id);
        }
    }
}
