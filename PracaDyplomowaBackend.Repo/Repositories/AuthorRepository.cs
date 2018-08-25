using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class AuthorRepository : RepositoryBase<Author, int>, IAuthorRepository
    {
        public AuthorRepository(DataContext context, IStringProvider stringProvider) : base(context, stringProvider)
        {
        }

        public void AddAuthorComment(AuthorComment authorComment)
        {
            _context.AuthorComments.Add(authorComment);
        }

        public void AddBookAuthor(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Add(bookAuthor);
        }
    }
}
