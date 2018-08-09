using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Common.User;
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
        public IActionResult Register(RegisterModel registerModel)
        {
            if(registerModel == null)
            {
                return BadRequest();
            }

            _userService.Register(registerModel);

            return Save(_userService, Ok());
        }
    }
}