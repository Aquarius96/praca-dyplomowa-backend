using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Role;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Role")]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public IActionResult AddRole([FromBody]AddRoleModel addRoleModel)
        {
            if(addRoleModel == null)
            {
                return BadRequest();
            }

            _roleService.Add(addRoleModel);

            return Save(_roleService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            if (!_roleService.Exists(role => role.Id == id))
            {
                return NotFound(ErrorMessages.RoleNotFound);
            }

            _roleService.Delete(id);

            return Save(_roleService, NoContent());
        }

        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            var role = _roleService.Get(id);

            if(role == null)
            {
                return NotFound(ErrorMessages.RoleNotFound);
            }

            return Ok(role);
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleService.GetList();

            return Ok(roles);
        }
    }
}