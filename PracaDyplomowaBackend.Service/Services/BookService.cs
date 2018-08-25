

using System.Collections.Generic;
using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Service.Services
{
    public class BookService : ServiceBase<Book, AddBookModel, BookDto, int>, IBookService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookService(IBookRepository repository, IGenreRepository genreRepository, IAuthorRepository authorRepository) : base(repository)
        {
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
        }

        public new void Add(AddBookModel model)
        {
            var book = Mapper.Map<Book>(model);

            _repository.Add(book);

            AddBookGenres(book, model.GenreIds);
            AddBookAuthors(book, model.AuthorIds);
        }

        public void AddBookAuthors(Book book, ICollection<int> authorIds)
        {
            foreach(var authorId in authorIds)
            {
                var bookAuthor = new BookAuthor { Book = book, AuthorId = authorId };

                _authorRepository.AddBookAuthor(bookAuthor);
            }
        }

        public void AddBookGenres(Book book, ICollection<int> genreIds)
        {
            foreach (var genreId in genreIds)
            {
                var bookGenre = new BookGenre { Book = book, GenreId = genreId };

                _genreRepository.AddBookGenre(bookGenre);
            }
        }

        public void DeleteBookGenre(int bookId, int genreId)
        {
            BookGenre bookGenre = _genreRepository.GetBookGenre(bookId, genreId);

            _genreRepository.RemoveBookGenre(bookGenre);
        }
    }
}
