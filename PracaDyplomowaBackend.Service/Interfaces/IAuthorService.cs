using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Author;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IAuthorService : IServiceBase<Author, AddAuthorModel, AuthorDto, int>
    {
        void AddAuthorGenres(Author author, ICollection<int> genreIds);             
    }
}
