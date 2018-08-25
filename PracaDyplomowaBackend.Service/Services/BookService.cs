

using System.Collections.Generic;
using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Service.Services
{
    public class BookService : ServiceBase<Book, AddBookModel, BookDto, int>, IBookService
    {
        private readonly IGenreRepository _genreRepository;
        public BookService(IBookRepository repository, IGenreRepository genreRepository) : base(repository)
        {
            _genreRepository = genreRepository;
        }

        public new void Add(AddBookModel model)
        {
            var book = Mapper.Map<Book>(model);

            _repository.Add(book);

            AddBookGenres(book, model.GenreIds);
        }

        public void AddBookGenres(Book book, ICollection<int> genreIds)
        {
            foreach (var genreId in genreIds)
            {
                var bookGenre = new BookGenre { Book = book, GenreId = genreId };

                _genreRepository.AddBookGenre(bookGenre);
            }
        }
    }
}
