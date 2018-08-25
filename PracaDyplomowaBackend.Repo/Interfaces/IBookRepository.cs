using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book, int>
    {
        void AddBookComment(BookComment bookComment);

        void DeleteBookComment(BookComment bookComment);

        BookComment GetBookComment(int id);

        IEnumerable<CommentDto> GetBookComments(int bookId);
    }
}
