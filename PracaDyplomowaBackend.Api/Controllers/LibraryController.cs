using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;
using System.Linq;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Library")]
    public class LibraryController : BaseController
    {
        private readonly ILibraryService _libraryService;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public LibraryController(ILibraryService libraryService, IUserService userService, IBookService bookService, IAuthorService authorService)
        {
            _libraryService = libraryService;
            _userService = userService;
            _bookService = bookService;
            _authorService = authorService;
        }

        [HttpPost("{userEmailAddress}/favoritebook/{bookId}")]
        public IActionResult AddFavoriteBook(string userEmailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_bookService.Exists(book => book.Id == bookId))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            _libraryService.AddFavoriteBook(userEmailAddress, bookId);

            return Save(_libraryService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{userEmailAddress}/wantedbook/{bookId}")]
        public IActionResult AddWantedBook(string userEmailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_bookService.Exists(book => book.Id == bookId))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            _libraryService.AddWantedBook(userEmailAddress, bookId);

            return Save(_libraryService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{userEmailAddress}/currentlyreadbook/{bookId}")]
        public IActionResult AddCurrentlyReadBook(string userEmailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_bookService.Exists(book => book.Id == bookId))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            _libraryService.AddCurrentlyReadBook(userEmailAddress, bookId);

            return Save(_libraryService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{userEmailAddress}/readbook")]
        public IActionResult AddReadBook(string userEmailAddress, [FromBody]AddReadBookModel addReadBookModel)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_bookService.Exists(book => book.Id == addReadBookModel.BookId))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            _libraryService.AddReadBook(userEmailAddress, addReadBookModel.BookId, addReadBookModel.Finished);

            return Save(_libraryService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{userEmailAddress}/favoriteauthor/{authorId}")]
        public IActionResult AddFavoriteAuthor(string userEmailAddress, int authorId)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_authorService.Exists(author => author.Id == authorId))
            {
                return NotFound(ErrorMessages.AuthorNotFound);
            }

            _libraryService.AddFavoriteAuthor(userEmailAddress, authorId);

            return Save(_libraryService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpDelete("{userEmailAddress}/favoritebook/{bookId}")]
        public IActionResult DeleteFavoriteBook(string userEmailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress && user.FavoriteBooks.Any(favoriteBook => favoriteBook.BookId == bookId)))
            {
                return NotFound(ErrorMessages.FavoriteBookNotFound);
            }

            _libraryService.DeleteFavoriteBook(userEmailAddress, bookId);

            return Save(_libraryService, NoContent());
        }

        [HttpDelete("{userEmailAddress}/wantedbook/{bookId}")]
        public IActionResult DeleteWantedBook(string userEmailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress && user.WantedBooks.Any(wantedBook => wantedBook.BookId == bookId)))
            {
                return NotFound(ErrorMessages.WantedBookNotFound);
            }

            _libraryService.DeleteWantedBook(userEmailAddress, bookId);

            return Save(_libraryService, NoContent());
        }

        [HttpDelete("{userEmailAddress}/currentlyreadbook/{bookId}")]
        public IActionResult DeleteCurrentlyReadBook(string userEmailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress && user.CurrentlyReadBooks.Any(currentlyReadBook => currentlyReadBook.BookId == bookId)))
            {
                return NotFound(ErrorMessages.CurrentlyReadBookNotFound);
            }

            _libraryService.DeleteCurrentlyReadBook(userEmailAddress, bookId);

            return Save(_libraryService, NoContent());
        }

        [HttpDelete("{userEmailAddress}/readbook/{bookId}")]
        public IActionResult DeleteReadBook(string userEmailAddress, int bookId)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress && user.ReadBooks.Any(readBook => readBook.BookId == bookId)))
            {
                return NotFound(ErrorMessages.ReadBookNotFound);
            }

            _libraryService.DeleteReadBook(userEmailAddress, bookId);

            return Save(_libraryService, NoContent());
        }

        [HttpDelete("{userEmailAddress}/favoriteauthor/{authorId}")]
        public IActionResult DeleteFavoriteAuthor(string userEmailAddress, int authorId)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress && user.FavoriteAuthors.Any(favoriteAuthor => favoriteAuthor.AuthorId == authorId)))
            {
                return NotFound(ErrorMessages.FavoriteAuthorNotFound);
            }

            _libraryService.DeleteFavoriteAuthor(userEmailAddress, authorId);

            return Save(_libraryService, NoContent());
        }
        
        [HttpGet("userEmailAddress")]
        public IActionResult GetUserLibrary(string userEmailAddress)
        {
            if (!_userService.Exists(user => user.EmailAddress == userEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            var library = _libraryService.GetUserLibrary(userEmailAddress);

            return Ok(library);
        }
    }
}