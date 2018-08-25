﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;
using PracaDyplomowaBackend.Utilities.Paging;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;

        public BookController(IBookService bookService, IGenreService genreService)
        {
            _bookService = bookService;
            _genreService = genreService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody]AddBookModel addBookModel)
        {
            if(addBookModel == null)
            {
                return BadRequest();
            }

            if (!_genreService.ListExists(addBookModel.GenreIds))
            {
                return NotFound(ErrorMessages.GenresNotFound);
            }

            _bookService.Add(addBookModel);

            return Save(_bookService, StatusCode(StatusCodes.Status201Created));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if(!_bookService.Exists(book => book.Id == id))
            {
                return NotFound();
            }

            _bookService.Delete(id);

            return Save(_bookService, NoContent());
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.Get(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetBooks(BookResourceParameters resourceParameters)
        {
            var books = _bookService.GetList(resourceParameters);
            
            return Ok(books);
        }
    }
}