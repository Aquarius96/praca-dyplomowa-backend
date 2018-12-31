using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;
using PracaDyplomowaBackend.Utilities.Paging;
using System.Linq;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    [Authorize]
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

        [AllowAnonymous]
        [HttpPost()]
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
        
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            if (!_userService.Exists(user => user.EmailAddress == loginModel.EmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            if (!_userService.Authenticate(loginModel))
            {
                return BadRequest(ErrorMessages.IncorrectPassword);
            }

            var token = _userService.CreateToken(loginModel);

            return Ok(token);
        }
        
        [HttpDelete("{emailAddress}")]
        public IActionResult DeleteUser(string emailAddress)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            _userService.Delete(emailAddress);

            return Save(_userService, NoContent());
        }

        [HttpGet("{emailAddress}")]
        public IActionResult GetUser(string emailAddress)
        {
            var user = _userService.Get(emailAddress);

            if(user == null)
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers(UserResourceParameters resourceParameters)
        {
            var users = _userService.GetList(resourceParameters);

            return Ok(users);
        }

        [HttpPost("changepassword/{emailAddress}")]
        public IActionResult ChangePassword(string emailAddress,[FromBody]ChangePasswordModel model)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            var passwordChanged = _userService.ChangePassword(emailAddress, model);

            if (passwordChanged)
            {
                return Save(_userService, Ok());
            }

            return BadRequest();
        }
    }
}