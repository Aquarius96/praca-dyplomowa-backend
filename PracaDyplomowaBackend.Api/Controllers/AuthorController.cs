using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Comment;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;
using PracaDyplomowaBackend.Utilities.Paging;
using System.Linq;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Author")]
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly IUserService _userService;

        public AuthorController(IAuthorService authorService, IGenreService genreService, IUserService userService)
        {
            _authorService = authorService;
            _genreService = genreService;
            _userService = userService;
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

        [HttpPost("{id}/comment")]
        public IActionResult AddAuthorComment(int id, [FromBody]AddCommentModel addCommentModel)
        {
            if (!_authorService.Exists(author => author.Id == id))
            {
                return NotFound(ErrorMessages.AuthorNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == addCommentModel.UserEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            _authorService.AddAuthorComment(id, addCommentModel.UserEmailAddress, addCommentModel.Content);

            return Save(_genreService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("{id}/genre/{genreId}")]
        public IActionResult AddAuthorGenre(int id, int genreId)
        {
            if(!_authorService.Exists(author => author.Id == id))
            {
                return NotFound(ErrorMessages.AuthorNotFound);
            }

            if (!_genreService.Exists(genre => genre.Id == genreId))
            {
                return NotFound(ErrorMessages.GenreNotFound);
            }

            _authorService.AddAuthorGenre(id, genreId);

            return Save(_genreService, StatusCode(StatusCodes.Status201Created));
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            if(!_authorService.Exists(author => author.Id == id))
            {
                return NotFound(ErrorMessages.AuthorNotFound);
            }

            _authorService.Delete(id);

            return Save(_authorService, NoContent());
        }

        [HttpDelete("{id}/genre/{genreId}")]
        public IActionResult DeleteAuthorGenre(int id, int genreId)
        {
            if (!_authorService.Exists(author => author.Id == id))
            {
                return NotFound(ErrorMessages.AuthorNotFound);
            }

            if(!_authorService.Exists(author => author.Id == id && author.AuthorGenres.Any(authorGenre => authorGenre.GenreId == genreId)))
            {
                return NotFound(ErrorMessages.AuthorGenreNotFound);
            }

            _authorService.DeleteAuthorGenre(id, genreId);

            return Save(_authorService, NoContent());
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {            
            var author = _authorService.Get(id);

            if(author == null)
            {
                return NotFound(ErrorMessages.AuthorNotFound);
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