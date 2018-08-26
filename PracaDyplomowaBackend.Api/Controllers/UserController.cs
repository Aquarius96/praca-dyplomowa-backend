using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;
using System.Linq;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public UserController(IUserService userService, IBookService bookService, IAuthorService authorService)
        {
            _userService = userService;
            _bookService = bookService;
            _authorService = authorService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel registerModel)
        {
            if(registerModel == null)
            {
                return BadRequest();
            }

            if(_userService.Exists(user => user.EmailAddress == registerModel.EmailAddress))
            {
                return BadRequest("Podany adres e-mail jest już zajęty.");
            }

            _userService.Register(registerModel);

            return Save(_userService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{emailAddress}/favoritebook/{bookId}")]
        public IActionResult AddFavoriteBook(string emailAddress, int bookId)
        {
            if(!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_bookService.Exists(book => book.Id == bookId))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            _userService.AddFavoriteBook(emailAddress, bookId);

            return Save(_userService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{emailAddress}/wantedbook/{bookId}")]
        public IActionResult AddWantedBook(string emailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_bookService.Exists(book => book.Id == bookId))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            _userService.AddWantedBook(emailAddress, bookId);

            return Save(_userService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{emailAddress}/currentlyreadbook/{bookId}")]
        public IActionResult AddCurrentlyReadBook(string emailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_bookService.Exists(book => book.Id == bookId))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            _userService.AddCurrentlyReadBook(emailAddress, bookId);

            return Save(_userService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{emailAddress}/readbook")]
        public IActionResult AddReadBook(string emailAddress, [FromBody]AddReadBookModel addReadBookModel)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_bookService.Exists(book => book.Id == addReadBookModel.BookId))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            _userService.AddReadBook(emailAddress, addReadBookModel.BookId, addReadBookModel.Finished);

            return Save(_userService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{emailAddress}/favoriteauthor/{authorId}")]
        public IActionResult AddFavoriteAuthor(string emailAddress, int authorId)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_authorService.Exists(author => author.Id == authorId))
            {
                return NotFound(ErrorMessages.AuthorNotFound);
            }

            _userService.AddFavoriteAuthor(emailAddress, authorId);

            return Save(_userService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpDelete("{emailAddress}/favoritebook/{bookId}")]
        public IActionResult DeleteFavoriteBook(string emailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == emailAddress && user.FavoriteBooks.Any(favoriteBook => favoriteBook.BookId == bookId)))
            {
                return NotFound(ErrorMessages.FavoriteBookNotFound);
            }

            _userService.DeleteFavoriteBook(emailAddress, bookId);

            return Save(_userService, NoContent());
        }

        [HttpDelete("{emailAddress}/wantedbook/{bookId}")]
        public IActionResult DeleteWantedBook(string emailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == emailAddress && user.WantedBooks.Any(wantedBook => wantedBook.BookId == bookId)))
            {
                return NotFound(ErrorMessages.WantedBookNotFound);
            }

            _userService.DeleteWantedBook(emailAddress, bookId);

            return Save(_userService, NoContent());
        }

        [HttpDelete("{emailAddress}/currentlyreadbook/{bookId}")]
        public IActionResult DeleteCurrentlyReadBook(string emailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == emailAddress && user.CurrentlyReadBooks.Any(currentlyReadBook => currentlyReadBook.BookId == bookId)))
            {
                return NotFound(ErrorMessages.CurrentlyReadBookNotFound);
            }

            _userService.DeleteCurrentlyReadBook(emailAddress, bookId);

            return Save(_userService, NoContent());
        }

        [HttpDelete("{emailAddress}/readbook/{bookId}")]
        public IActionResult DeleteReadBook(string emailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == emailAddress && user.ReadBooks.Any(readBook => readBook.BookId == bookId)))
            {
                return NotFound(ErrorMessages.ReadBookNotFound);
            }

            _userService.DeleteReadBook(emailAddress, bookId);

            return Save(_userService, NoContent());
        }

        [HttpDelete("{emailAddress}/favoriteauthor/{authorId}")]
        public IActionResult DeleteFavoriteAuthor(string emailAddress, int authorId)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == emailAddress && user.FavoriteAuthors.Any(favoriteAuthor => favoriteAuthor.AuthorId == authorId)))
            {
                return NotFound(ErrorMessages.FavoriteAuthorNotFound);
            }

            _userService.DeleteFavoriteAuthor(emailAddress, authorId);

            return Save(_userService, NoContent());
        }
    }
}