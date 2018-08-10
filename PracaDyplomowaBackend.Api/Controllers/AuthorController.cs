using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/author")]
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
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetList();

            if(authors.Count() == 0)
            {
                return NotFound();
            }

            return Ok(authors);
        }
    }
}