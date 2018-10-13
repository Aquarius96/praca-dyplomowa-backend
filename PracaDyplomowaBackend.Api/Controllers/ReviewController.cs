using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.Models.Rate;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;
using System.Linq;

namespace PracaDyplomowaBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : BaseController
    {
        private readonly IReviewService _reviewService;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public ReviewController(IReviewService reviewService, IBookService bookService, IUserService userService)
        {
            _reviewService = reviewService;
            _bookService = bookService;
            _userService = userService;
        }

        [HttpPost()]
        public IActionResult AddBookReview([FromBody]AddBookReviewModel addBookReviewModel)
        {
            if (!_bookService.Exists(book => book.Id == addBookReviewModel.BookId))
            {
                return NotFound(ErrorMessages.BookNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == addBookReviewModel.UserEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            var review = _reviewService.Add(addBookReviewModel);

            return Save(_reviewService, CreatedAtAction(nameof(GetBookReview), new { review.Id }, null), review, "Get");
        }

        [HttpPost("{id}/rate")]
        public IActionResult AddBookReviewRate(int id, [FromBody]AddBookReviewRateModel addBookReviewRateModel)
        {
            if (!_reviewService.Exists(bookReview => bookReview.Id == id))
            {
                return NotFound(ErrorMessages.BookReviewNotFound);
            }

            if (!_userService.Exists(user => user.EmailAddress == addBookReviewRateModel.UserEmailAddress))
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            _reviewService.AddBookReviewRate(id, addBookReviewRateModel.UserEmailAddress, addBookReviewRateModel.Value);

            return Save(_reviewService, CreatedAtAction(nameof(GetBookReview), new { id }, null), id, "GetBookReviewRating");
        }

        [HttpPost("{id}/confirm")]
        public IActionResult ConfirmReview(int id)
        {
            if (!_reviewService.Exists(bookReview => bookReview.Id == id))
            {
                return NotFound(ErrorMessages.BookReviewNotFound);
            }

            _reviewService.ConfirmReview(id);

            return Save(_reviewService, NoContent());
        }

        [HttpGet("{id}")]
        public IActionResult GetBookReview(int id)
        {
            var bookReview = _reviewService.Get(id);

            if (bookReview == null)
            {
                return NotFound(ErrorMessages.BookReviewNotFound);
            }

            return Ok(bookReview);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookReview(int id)
        {
            if (!_reviewService.Exists(bookReview => bookReview.Id == id))
            {
                return NotFound(ErrorMessages.BookReviewNotFound);
            }

            _reviewService.Delete(id);

            return Save(_reviewService, NoContent());
        }

        [HttpDelete("{id}/rate/{userEmailAddress}")]
        private IActionResult DeleteBookReviewRate(int id, string userEmailAddress)
        {
            if (!_reviewService.Exists(bookReview => bookReview.ReviewRates.Any(bookReviewRate => bookReviewRate.BookReviewId == id && bookReviewRate.User.EmailAddress == userEmailAddress)))
            {
                return NotFound(ErrorMessages.RateNotFound);
            }

            _reviewService.DeleteBookReviewRate(id, userEmailAddress);

            return Save(_bookService, NoContent());
        }

        [HttpGet()]
        public IActionResult GetReviews()
        {
            var reviews = _reviewService.GetList();

            return Ok(reviews);
        }
    }
}