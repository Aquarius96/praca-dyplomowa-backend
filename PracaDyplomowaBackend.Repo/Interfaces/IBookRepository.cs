using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book, int>
    {
        void AddBookComment(BookComment bookComment);
        void AddBookReview(BookReview bookReview);

        void DeleteBookComment(BookComment bookComment);
        void DeleteBookReview(BookReview bookReview);

        BookComment GetBookComment(int id);
        BookReview GetBookReview(int id);
        
        IEnumerable<CommentDto> GetBookComments(int bookId);
        IEnumerable<BookReviewDto> GetBookReviews(int bookId);
    }
}
