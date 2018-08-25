using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IAuthorRepository : IRepositoryBase<Author, int>
    {
        void AddBookAuthor(BookAuthor bookAuthor);
        void AddAuthorComment(AuthorComment authorComment);

        void DeleteAuthorComment(AuthorComment authorComment);

        AuthorComment GetAuthorComment(int id);

        IEnumerable<CommentDto> GetAuthorComments(int authorId);
    }
}
