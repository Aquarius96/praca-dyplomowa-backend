using System;
using System.Collections.Generic;
using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.Paging;

namespace PracaDyplomowaBackend.Service.Services
{
    public class BookService : ServiceBase<Book, AddBookModel, BookDto, int>, IBookService
    {
        private new readonly IBookRepository _repository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IUserRepository _userRepository;

        public BookService(IBookRepository repository, IGenreRepository genreRepository, IAuthorRepository authorRepository, IUserRepository userRepository) : base(repository)
        {
            _repository = repository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
            _userRepository = userRepository;
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

        public void AddBookComment(int bookId, string userEmailAddress, string content)
        {
            var user = _userRepository.Get(userEmailAddress);

            var bookComment = new BookComment { BookId = bookId, User = user, Content = content, Added = DateTime.UtcNow };

            _repository.AddBookComment(bookComment);
        }

        public void AddBookGenre(int bookId, int genreId)
        {
            var bookGenre = new BookGenre { BookId = bookId, GenreId = genreId };

            _genreRepository.AddBookGenre(bookGenre);
        }

        public void AddBookGenres(Book book, ICollection<int> genreIds)
        {
            foreach (var genreId in genreIds)
            {
                var bookGenre = new BookGenre { Book = book, GenreId = genreId };

                _genreRepository.AddBookGenre(bookGenre);
            }
        }

        public void AddBookReview(int bookId, string userEmailAddress, string title, string content)
        {
            var user = _userRepository.Get(userEmailAddress);

            var bookReview = new BookReview { BookId = bookId, User = user, Title = title, Content = content, Added = DateTime.UtcNow };

            _repository.AddBookReview(bookReview);
        }

        public void DeleteBookComment(int id)
        {
            var bookComment = _repository.GetBookComment(id);

            _repository.DeleteBookComment(bookComment);
        }

        public void DeleteBookGenre(int bookId, int genreId)
        {
            BookGenre bookGenre = _genreRepository.GetBookGenre(bookId, genreId);

            _genreRepository.DeleteBookGenre(bookGenre);
        }

        public void DeleteBookReview(int id)
        {
            var bookReview = _repository.GetBookReview(id);

            _repository.DeleteBookReview(bookReview);
        }

        public new BookDto Get(int id)
        {
            var book = Mapper.Map<BookDto>(_repository.Get(id));

            if (book != null)
            {
                book.Authors = _authorRepository.GetBookAuthors(id);
                book.Genres = _genreRepository.GetBookGenres(id);
                book.Comments = _repository.GetBookComments(id);
                book.Reviews = _repository.GetBookReviews(id);
            }            

            return book;
        }
        
        public new IEnumerable<BookDto> GetList(ResourceParameters resourceParameters)
        {
            var books = Mapper.Map<IEnumerable<BookDto>>(_repository.GetList(resourceParameters));

            foreach (var book in books)
            {
                book.Authors = _authorRepository.GetBookAuthors(book.Id);
                book.Genres = _genreRepository.GetBookGenres(book.Id);
                book.Reviews = _repository.GetBookReviews(book.Id);
            }

            return books;
        }
    }
}
