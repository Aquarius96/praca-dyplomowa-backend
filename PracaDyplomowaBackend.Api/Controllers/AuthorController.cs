using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;
using PracaDyplomowaBackend.Utilities.Paging;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Author")]
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;

        public AuthorController(IAuthorService authorService, IGenreService genreService)
        {
            _authorService = authorService;
            _genreService = genreService;
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody]AddAuthorModel addAuthorModel)
        {
            if(addAuthorModel == null)
            {
                return BadRequest();
            }

            if (!_genreService.ListExists(addAuthorModel.GenreIds))
            {
                return NotFound(ErrorMessages.GenresNotFound);
            }

            _authorService.Add(addAuthorModel);

            return Save(_authorService, StatusCode(StatusCodes.Status201Created));
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
            
            return Ok(authors);
        }
    }
}