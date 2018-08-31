using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IAuthorRepository : IRepositoryBase<Author, int>
    {
        void AddBookAuthor(BookAuthor bookAuthor);
        void AddAuthorComment(AuthorComment authorComment);
        void AddAuthorRate(AuthorRate authorRate);

        void DeleteAuthorComment(AuthorComment authorComment);
        void DeleteAuthorRate(AuthorRate authorRate);

        AuthorComment GetAuthorComment(int id);
        AuthorRate GetAuthorRate(int authorId, string userEmailAddress);

        IEnumerable<CommentDto> GetAuthorComments(int authorId);
        IEnumerable<BookAuthorDto> GetBookAuthors(int bookId);
    }
}
