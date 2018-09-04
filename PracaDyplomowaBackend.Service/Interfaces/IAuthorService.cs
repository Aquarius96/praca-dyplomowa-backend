using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Author;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IAuthorService : IServiceBase<Author, AddAuthorModel, AuthorDto, int>
    {
        void AddAuthorGenre(int authorId, int genreId);
        void AddAuthorGenres(Author author, ICollection<int> genreIds);
        void AddAuthorComment(int authorId, string userEmailAddress, string content);
        void AddAuthorRate(int authorId, string userEmailAddress, int value);
        void AddImage(int authorId, string imageUrl);

        void DeleteAuthorGenre(int authorId, int genreId);
        void DeleteAuthorComment(int id);
        void DeleteAuthorRate(int authorId, string userEmailAddress);
    }
}
