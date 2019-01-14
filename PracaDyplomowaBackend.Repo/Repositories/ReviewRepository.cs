using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class ReviewRepository : RepositoryBase<BookReview, int>, IReviewRepository
    {
        public ReviewRepository(DataContext context, IStringProvider stringProvider) : base(context, stringProvider)
        {
        }

        public void AddBookReviewRate(BookReviewRate bookReviewRate)
        {
            _context.ReviewRates.Add(bookReviewRate);
        }

        public void DeleteBookReviewRate(BookReviewRate bookReviewRate)
        {
            _context.ReviewRates.Remove(bookReviewRate);
        }

        public new BookReview Get(int id)
        {
            return _context.BookReviews.Where(review => review.Id == id).Include(bookReview => bookReview.Book).ThenInclude(book => book.BookGenres).ThenInclude(bookGenre => bookGenre.Genre).Include(bookReview => bookReview.Book).ThenInclude(book => book.BookAuthors).ThenInclude(bookAuthor => bookAuthor.Author).Include(bookReview => bookReview.User).FirstOrDefault();
        }

        public new IEnumerable<BookReview> GetList()
        {
            var reviews = _context.BookReviews.Include(bookReview => bookReview.Book).ThenInclude(book => book.BookGenres).ThenInclude(bookGenre => bookGenre.Genre).Include(bookReview => bookReview.Book).ThenInclude(book => book.BookAuthors).ThenInclude(bookAuthor => bookAuthor.Author).Include(bookReview => bookReview.User);

            return reviews;
        }        

        public IEnumerable<BookReviewDto> GetBookReviews(int bookId)
        {
            var bookReviews = _context.BookReviews.Where(bookReview => bookReview.BookId == bookId).Include(bookReview => bookReview.Book).ThenInclude(book => book.BookGenres).ThenInclude(bookGenre => bookGenre.Genre).Include(bookReview => bookReview.Book).ThenInclude(book => book.BookAuthors).ThenInclude(bookAuthor => bookAuthor.Author).Include(bookReview => bookReview.User);

            return Mapper.Map<IEnumerable<BookReviewDto>>(bookReviews);
        }

        public BookReviewRate GetBookReviewRate(int bookReviewId, string userEmailAddress)
        {
            return _context.ReviewRates.FirstOrDefault(bookReviewRate => bookReviewRate.BookReviewId == bookReviewId && bookReviewRate.User.EmailAddress == userEmailAddress);
        }

        public RateDto GetBookReviewRating(int bookReviewId)
        {
            if (_context.ReviewRates.Where(bookReviewRate => bookReviewRate.BookReviewId == bookReviewId).Count() == 0)
            {
                return new RateDto { Value = 0, VotesAmount = 0 };
            }

            var rateDto = new RateDto { Value = Math.Round(Convert.ToDouble(_context.ReviewRates.Where(bookReviewRate => bookReviewRate.BookReviewId == bookReviewId && bookReviewRate.Value).Count()) / _context.ReviewRates.Where(bookReviewRate => bookReviewRate.BookReviewId == bookReviewId).Count(), 2) * 100, VotesAmount = _context.ReviewRates.Where(bookReviewRate => bookReviewRate.BookReviewId == bookReviewId).Count() };

            return rateDto;
        }
    }
}
