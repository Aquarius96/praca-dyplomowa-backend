using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
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
        private readonly IReviewRepository _reviewRepository;

        public BookService(IBookRepository repository, IGenreRepository genreRepository, IAuthorRepository authorRepository, IUserRepository userRepository, IReviewRepository reviewRepository) : base(repository)
        {
            _repository = repository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
            _userRepository = userRepository;
            _reviewRepository = reviewRepository;
        }

        public new Book Add(AddBookModel model)
        {
            var book = Mapper.Map<Book>(model);

            _repository.Add(book);

            AddBookGenres(book, model.GenreIds);
            AddBookAuthors(book, model.AuthorIds);

            return book;
        }

        public void AddBookAuthors(Book book, ICollection<int> authorIds)
        {
            foreach(var authorId in authorIds)
            {
                var bookAuthor = new BookAuthor { Book = book, AuthorId = authorId };

                _authorRepository.AddBookAuthor(bookAuthor);
            }
        }

        public BookComment AddBookComment(int bookId, string userEmailAddress, string content)
        {
            var user = _userRepository.Get(userEmailAddress);

            var bookComment = new BookComment { BookId = bookId, User = user, Content = content, Added = DateTime.UtcNow };

            _repository.AddBookComment(bookComment);

            return bookComment;
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

        public void AddBookRate(int bookId, string userEmailAddress, int value)
        {
            var user = _userRepository.Get(userEmailAddress);

            var bookRate = _repository.GetBookRate(bookId, userEmailAddress);

            if (bookRate == null)
            {
                bookRate = new BookRate { BookId = bookId, User = user, Value = value };
                _repository.AddBookRate(bookRate);
            }            
            else
            {
                bookRate.Value = value;
            }            
        }
        
        public void AddImage(int bookId, string imageUrl)
        {
            var book = _repository.Get(bookId);

            book.PhotoUrl = imageUrl;
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

        public void DeleteBookRate(int bookId, string userEmailAddress)
        {
            BookRate bookRate = _repository.GetBookRate(bookId, userEmailAddress);

            _repository.DeleteBookRate(bookRate);
        }

        public new BookDto Get(int id)
        {
            var book = Mapper.Map<BookDto>(_repository.Get(id));

            if (book != null)
            {
                var reviews = _reviewRepository.GetBookReviews(id);

                foreach (var review in reviews)
                {
                    review.Rating = _reviewRepository.GetBookReviewRating(review.Id);
                }

                book.Authors = _authorRepository.GetBookAuthors(id);
                book.Genres = _genreRepository.GetBookGenres(id);
                book.Comments = _repository.GetBookComments(id);
                book.Reviews = reviews;
                book.Rating = _repository.GetBookRating(id);
            }            

            return book;
        }

        public CommentDto GetBookComment(int commentId)
        {
            return Mapper.Map<CommentDto>(_repository.GetBookComment(commentId));
        }

        public RateDto GetBookRating(int bookId)
        {
            return _repository.GetBookRating(bookId);
        }
        
        public new IEnumerable<BookDto> GetList(ResourceParameters resourceParameters)
        {
            var books = Mapper.Map<IEnumerable<BookDto>>(_repository.GetList(resourceParameters));

            foreach (var book in books)
            {
                var reviews = _reviewRepository.GetBookReviews(book.Id);

                foreach (var review in reviews)
                {
                    review.Rating = _reviewRepository.GetBookReviewRating(review.Id);
                }

                book.Authors = _authorRepository.GetBookAuthors(book.Id);
                book.Genres = _genreRepository.GetBookGenres(book.Id);
                book.Comments = _repository.GetBookComments(book.Id);
                book.Reviews = reviews;
                book.Rating = _repository.GetBookRating(book.Id);
            }

            if(resourceParameters.SortByRating)
            {
                return books.OrderByDescending(book => book.Rating.Value).ThenByDescending(book => book.Rating.VotesAmount);
            }

            return books;
        }        
    }
}
