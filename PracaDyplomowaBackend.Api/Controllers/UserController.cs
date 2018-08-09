using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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

            return Save(_userService, Ok());
        }
    }
}