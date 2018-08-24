using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Author;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Service.Services
{
    public class AuthorService : ServiceBase<Author,AddAuthorModel, AuthorDto, int>, IAuthorService
    {
        private readonly IGenreRepository _genreRepository;
        public AuthorService(IAuthorRepository repository, IGenreRepository genreRepository) : base(repository)
        {
            _genreRepository = genreRepository;
        }

        public new void Add(AddAuthorModel model)
        {
            var author = Mapper.Map<Author>(model);

            _repository.Add(author);

            AddAuthorGenres(author, model.GenreIds);
        }

        public void AddAuthorGenres(Author author, ICollection<int> genreIds)
        {
            foreach(var genreId in genreIds)
            {
                var authorGenre = new AuthorGenre { Author = author, GenreId = genreId };

                _genreRepository.AddAuthorGenre(authorGenre);
            }
        }
    }
}
