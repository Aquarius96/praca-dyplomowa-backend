using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book, int>
    {
        void AddBookComment(BookComment bookComment);
        void AddBookRate(BookRate bookRate);

        void DeleteBookComment(BookComment bookComment);
        void DeleteBookRate(BookRate bookRate);

        BookComment GetBookComment(int id);
        BookRate GetBookRate(int bookId, string userEmailAddress);
        RateDto GetBookRating(int bookId);
        
        IEnumerable<CommentDto> GetBookComments(int bookId);
    }
}
