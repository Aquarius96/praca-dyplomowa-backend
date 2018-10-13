using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Models.Models.Comment;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.Models.Rate;
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
        private readonly IUserService _userService;

        public BookController(IBookService bookService, IGenreService genreService, IAuthorService authorService, IUserService userService)
        {
            _bookService = bookService;
            _genreService = genreService;
            _authorService = authorService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody]AddBookModel addBookModel)
        {
            if (addBookModel == null)
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

            var book = _bookService.Add(addBookModel);

            return Save(_bookService, CreatedAtAction(nameof(GetBook), new { book.Id }, null), book, "Get");
        }

        [HttpPost("{id}/genre/{genreId}")]
        private IActionResult AddBookGenre(int id, int genreId)
        {
            if (!_bookService.Exists(book => book.Id == id))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            if (!_genreService.Exists(genre => genre.Id == genreId))
            {
                return NotFound(ErrorMessages.GenreNotFound);
            }

            _bookService.AddBookGenre(id, genreId);

            return Save(_bookService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{id}/comment")]
        public IActionResult AddBookComment(int id, [FromBody]AddCommentModel addCommentModel)
        {
            if (!_bookService.Exists(book => book.Id == id))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == addCommentModel.UserEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            BookComment comment = _bookService.AddBookComment(id, addCommentModel.UserEmailAddress, addCommentModel.Content);

            return Save(_bookService, CreatedAtAction(nameof(GetBook), new { comment.Id }, null), "GetBookComment", comment);
        }

        [HttpPost("{id}/rate")]
        public IActionResult AddBookRate(int id, [FromBody]AddRateModel addRateModel)
        {
            if (!_bookService.Exists(book => book.Id == id))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == addRateModel.UserEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            _bookService.AddBookRate(id, addRateModel.UserEmailAddress, addRateModel.Value);

            return Save(_bookService, CreatedAtAction(nameof(GetBook), new { id }, null), id, "GetBookRating");
        }

        [HttpPost("{id}/confirm")]
        public IActionResult ConfirmBook(int id)
        {
            if (!_bookService.Exists(book => book.Id == id))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            _bookService.ConfirmBook(id);

            return Save(_bookService, NoContent());
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
        private IActionResult DeleteBookGenre(int id, int genreId)
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

        [HttpDelete("comment/{commentId}")]
        public IActionResult DeleteBookComment(int commentId)
        {
            if (!_bookService.Exists(book => book.BookComments.Any(bookComment => bookComment.Id == commentId)))
            {
                return NotFound(ErrorMessages.CommentNotFound);
            }

            _bookService.DeleteBookComment(commentId);

            return Save(_bookService, NoContent());
        }        

        [HttpDelete("rate/{bookId}/{userEmailAddress}")]
        private IActionResult DeleteBookRate(int bookId, string userEmailAddress)
        {
            if (!_bookService.Exists(book => book.BookRates.Any(bookRate => bookRate.BookId == bookId && bookRate.User.EmailAddress == userEmailAddress)))
            {
                return NotFound(ErrorMessages.RateNotFound);
            }

            _bookService.DeleteBookRate(bookId, userEmailAddress);

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