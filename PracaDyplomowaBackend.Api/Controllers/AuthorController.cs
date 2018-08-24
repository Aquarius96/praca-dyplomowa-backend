using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.Paging;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Author")]
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody]AddAuthorModel addAuthorModel)
        {
            if(addAuthorModel == null)
            {
                return BadRequest();
            }

            _authorService.Add(addAuthorModel);

            return Save(_authorService, Ok("Autor został pomyślnie dodany do bazy."));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            if(!_authorService.Exists(author => author.Id == id))
            {
                return NotFound();
            }

            _authorService.Delete(id);

            return Save(_authorService, NoContent());
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {            
            var author = _authorService.Get(id);

            if(author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpGet]
        public IActionResult GetAuthors(AuthorResourceParameters resourceParameters)
        {
            var authors = _authorService.GetList(resourceParameters);

            if(authors.Count() == 0)
            {
                return NotFound();
            }

            return Ok(authors);
        }
    }
}