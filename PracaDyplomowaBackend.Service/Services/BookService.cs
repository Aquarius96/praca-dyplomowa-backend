

using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Service.Services
{
    public class BookService : ServiceBase<Book, AddBookModel, BookDto, int>, IBookService
    {
        public BookService(IBookRepository repository) : base(repository)
        {
        }
    }
}
