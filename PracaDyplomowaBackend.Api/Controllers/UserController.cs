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

        public UserController(IUserService userService, IBookService bookService)
        {
            _userService = userService;
            _bookService = bookService;
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
    }
}