using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class BookRepository : RepositoryBase<Book, int>, IBookRepository
    {
        public BookRepository(DataContext context, IStringProvider stringProvider) : base(context, stringProvider)
        {
        }

        public void AddBookComment(BookComment bookComment)
        {
            _context.BookComments.Add(bookComment);
        }

        public void AddBookRate(BookRate bookRate)
        {
            _context.BookRates.Add(bookRate);
        }

        public void AddBookReview(BookReview bookReview)
        {
            _context.BookReviews.Add(bookReview);
        }

        public void AddBookReviewRate(BookReviewRate bookReviewRate)
        {
            _context.ReviewRates.Add(bookReviewRate);
        }

        public void DeleteBookComment(BookComment bookComment)
        {
            _context.BookComments.Remove(bookComment);
        }

        public void DeleteBookRate(BookRate bookRate)
        {
            _context.BookRates.Remove(bookRate);
        }

        public void DeleteBookReview(BookReview bookReview)
        {
            _context.BookReviews.Remove(bookReview);
        }

        public void DeleteBookReviewRate(BookReviewRate bookReviewRate)
        {
            _context.ReviewRates.Remove(bookReviewRate);
        }

        public IEnumerable<LibraryBookDto> GetAuthorBooks(int authorId)
        {
            var authorBooks = _context.Books.Where(book => book.BookAuthors.Any(bookAuthor => bookAuthor.AuthorId == authorId)).Include(book => book.BookGenres).ThenInclude(bookGenre => bookGenre.Genre);

            return Mapper.Map<IEnumerable<LibraryBookDto>>(authorBooks);
        }

        public BookComment GetBookComment(int id)
        {
            return _context.BookComments.FirstOrDefault(bookComment => bookComment.Id == id);
        }

        public IEnumerable<CommentDto> GetBookComments(int bookId)
        {
            var bookComments = _context.Books.Where(book => book.Id == bookId).SelectMany(book => book.BookComments).Include(bookComment => bookComment.User);

            return Mapper.Map<IEnumerable<CommentDto>>(bookComments);
        }

        public BookRate GetBookRate(int bookId, string userEmailAddress)
        {
            return _context.BookRates.FirstOrDefault(bookRate => bookRate.BookId == bookId && bookRate.User.EmailAddress == userEmailAddress);
        }

        public RateDto GetBookRating(int bookId)
        {
            var rateDto = new RateDto { Value = 0, VotesAmount = 0 };

            if (_context.BookRates.Where(bookRate => bookRate.BookId == bookId).Count() != 0)
            {
                rateDto = new RateDto { Value = Math.Round(_context.BookRates.Where(bookRate => bookRate.BookId == bookId).Average(book => book.Value), 2), VotesAmount = _context.BookRates.Where(bookRate => bookRate.BookId == bookId).Count() };
            }            

            return rateDto;
        }

        public BookReview GetBookReview(int id)
        {
            return _context.BookReviews.FirstOrDefault(bookReview => bookReview.Id == id);
        }

        

        

        public IEnumerable<BookReviewDto> GetBookReviews(int bookId)
        {
            var bookReviews = _context.BookReviews.Where(bookReview => bookReview.BookId == bookId).Include(bookReview => bookReview.Book).ThenInclude(book => book.BookGenres).ThenInclude(bookGenre => bookGenre.Genre).Include(bookReview => bookReview.Book).ThenInclude(book => book.BookAuthors).ThenInclude(bookAuthor => bookAuthor.Author).Include(bookReview => bookReview.User);

            return Mapper.Map<IEnumerable<BookReviewDto>>(bookReviews);
        }

        public IEnumerable<ReviewDto> GetReviews()
        {
            var reviews = _context.BookReviews.Include(bookReview => bookReview.Book).ThenInclude(book => book.BookGenres).ThenInclude(bookGenre => bookGenre.Genre).Include(bookReview => bookReview.Book).ThenInclude(book => book.BookAuthors).ThenInclude(bookAuthor => bookAuthor.Author).Include(bookReview => bookReview.User);

            return Mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }
    }
}
