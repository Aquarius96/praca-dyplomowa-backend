using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book, int>
    {
        void AddBookComment(BookComment bookComment);
        void AddBookReview(BookReview bookReview);
        void AddBookRate(BookRate bookRate);
        void AddBookReviewRate(ReviewRate reviewRate);

        void DeleteBookComment(BookComment bookComment);
        void DeleteBookReview(BookReview bookReview);
        void DeleteBookRate(BookRate bookRate);
        void DeleteBookReviewRate(ReviewRate reviewRate);

        BookComment GetBookComment(int id);
        BookReview GetBookReview(int id);
        BookRate GetBookRate(int bookId, string userEmailAddress);
        ReviewRate GetBookReviewRate(int bookReviewId, string userEmailAddress);
        
        IEnumerable<CommentDto> GetBookComments(int bookId);
        IEnumerable<BookReviewDto> GetBookReviews(int bookId);
    }
}
