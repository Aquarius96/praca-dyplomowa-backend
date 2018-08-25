using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;
using PracaDyplomowaBackend.Utilities.Paging;
using System.Linq;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IGenreService genreService, IAuthorService authorService)
        {
            _bookService = bookService;
            _genreService = genreService;
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody]AddBookModel addBookModel)
        {
            if(addBookModel == null)
            {
                return BadRequest();
            }

            if (!_genreService.ListExists(addBookModel.GenreIds))
            {
                return NotFound(ErrorMessages.GenresNotFound);
            }

            if (!_authorService.ListExists(addBookModel.AuthorIds))
            {
                return NotFound(ErrorMessages.AuthorsNotFound);
            }

            _bookService.Add(addBookModel);

            return Save(_bookService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if(!_bookService.Exists(book => book.Id == id))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            _bookService.Delete(id);

            return Save(_bookService, NoContent());
        }

        [HttpDelete("{id}/genre/{genreId}")]
        public IActionResult DeleteBookGenre(int id, int genreId)
        {
            if(!_bookService.Exists(book => book.Id == id))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            if(!_bookService.Exists(book => book.Id == id && book.BookGenres.Any(bookGenre => bookGenre.GenreId == genreId)))
            {
                return NotFound(ErrorMessages.BookGenreNotFound);
            }

            _bookService.DeleteBookGenre(id, genreId);

            return Save(_bookService, NoContent());
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.Get(id);

            if(book == null)
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetBooks(BookResourceParameters resourceParameters)
        {
            var books = _bookService.GetList(resourceParameters);
            
            return Ok(books);
        }
    }
}