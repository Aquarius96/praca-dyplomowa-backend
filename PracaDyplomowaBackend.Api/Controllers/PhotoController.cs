using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;
using System;
using System.IO;
using System.Linq;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Photo")]    
    public class PhotoController : BaseController
    {
        private readonly IHostingEnvironment _environment;
        private readonly IUserService _userService;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public PhotoController(IHostingEnvironment environment, IUserService userService, IAuthorService authorService, IBookService bookService)
        {
            _environment = environment;
            _userService = userService;
            _authorService = authorService;
            _bookService = bookService;
        }

        [HttpPost("user/{emailAddress}")]
        public IActionResult AddUserImage(string emailAddress, IFormFile file)
        {
            if (!_userService.Exists(user => user.EmailAddress == emailAddress))
            {
                return BadRequest(ErrorMessages.UserNotFound);
            }

            if(file == null)
            {
                return BadRequest(ErrorMessages.NullFile);
            }

            string fileName = SaveFile(_environment, file);

            _userService.AddImage(emailAddress, GenerateImageUrl(fileName));

            return Save(_userService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("author/{id}")]
        public IActionResult AddAuthorImage(int id, IFormFile file)
        {
            if (!_authorService.Exists(author => author.Id == id))
            {
                return NotFound(ErrorMessages.AuthorNotFound);
            }

            if (file == null)
            {
                return BadRequest(ErrorMessages.NullFile);
            }

            string fileName = SaveFile(_environment, file);

            _authorService.AddImage(id, GenerateImageUrl(fileName));

            return Save(_authorService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpPost("book/{id}")]
        public IActionResult AddBookImage(int id, IFormFile file)
        {
            if (!_bookService.Exists(book => book.Id == id))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            if (file == null)
            {
                return BadRequest(ErrorMessages.NullFile);
            }

            string fileName = SaveFile(_environment, file);

            _bookService.AddImage(id, GenerateImageUrl(fileName));

            return Save(_bookService, StatusCode(StatusCodes.Status201Created));
        }

        [AllowAnonymous]
        [HttpGet("{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            var stream = _environment.ContentRootPath + "\\Uploads\\" + fileName;

            if (!System.IO.File.Exists(stream))
            {
                return NotFound(ErrorMessages.ImageNotFound);
            }

            var imageFileStream = System.IO.File.OpenRead(stream);

            return File(imageFileStream, "image/jpeg");
        }

        private static string SaveFile(IHostingEnvironment environment, IFormFile file)
        {
            string directory = Path.Combine(environment.ContentRootPath, "Uploads");
            string fileName = GenerateFileName(file.FileName);

            Directory.CreateDirectory(directory);

            using (var fileStream = new FileStream(Path.Combine(directory, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }

        private static string GenerateFileName(string fileName)
        {
            return Guid.NewGuid().ToString() + "." + fileName.Split(".").Last();
        }

        private static string GenerateImageUrl(string fileName)
        {
            return "http://localhost:8000/api/photo/" + fileName;
        }
    }
}

