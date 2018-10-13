using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IAuthorService : IServiceBase<Author, AddAuthorModel, AuthorDto, int>
    {
        void AddAuthorGenre(int authorId, int genreId);
        void AddAuthorGenres(Author author, ICollection<int> genreIds);
        AuthorComment AddAuthorComment(int authorId, string userEmailAddress, string content);
        void AddAuthorRate(int authorId, string userEmailAddress, int value);
        void AddImage(int authorId, string imageUrl);
        void ConfirmAuthor(int authorId);

        void DeleteAuthorGenre(int authorId, int genreId);
        void DeleteAuthorComment(int id);
        void DeleteAuthorRate(int authorId, string userEmailAddress);

        RateDto GetAuthorRating(int authorId);
        CommentDto GetAuthorComment(int commentId);
    }
}
