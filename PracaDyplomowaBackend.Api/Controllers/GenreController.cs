using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Genre;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Genre")]
    public class GenreController : BaseController
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody]AddGenreModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }

            _genreService.Add(model);

            return Save(_genreService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            if(!_genreService.Exists(genre => genre.Id == id))
            {
                return NotFound();
            }

            _genreService.Delete(id);

            return Save(_genreService, NoContent());
        }

        [HttpGet("{id}")]
        public IActionResult GetGenre(int id)
        {
            var genre = _genreService.Get(id);

            if(genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            var genres = _genreService.GetList();

            return Ok(genres);
        }
    }
}