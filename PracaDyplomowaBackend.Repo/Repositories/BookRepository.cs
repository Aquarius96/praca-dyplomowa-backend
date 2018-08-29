using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
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

        public void AddBookReview(BookReview bookReview)
        {
            _context.BookReviews.Add(bookReview);
        }

        public void DeleteBookComment(BookComment bookComment)
        {
            _context.BookComments.Remove(bookComment);
        }

        public void DeleteBookReview(BookReview bookReview)
        {
            _context.BookReviews.Remove(bookReview);
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

        public BookReview GetBookReview(int id)
        {
            return _context.BookReviews.FirstOrDefault(bookReview => bookReview.Id == id);
        }

        public IEnumerable<BookReviewDto> GetBookReviews(int bookId)
        {
            var bookReviews = _context.BookReviews.Where(bookReview => bookReview.BookId == bookId);

            return Mapper.Map<IEnumerable<BookReviewDto>>(bookReviews);
        }
    }
}
