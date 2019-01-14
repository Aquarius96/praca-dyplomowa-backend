using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Service.Services
{
    public class ReviewService : ServiceBase<BookReview, AddBookReviewModel, ReviewDto, int>, IReviewService
    {
        private new readonly IReviewRepository _repository;
        private readonly IUserRepository _userRepository;

        public ReviewService(IReviewRepository repository, IUserRepository userRepository) : base(repository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public new BookReview Add(AddBookReviewModel model)
        {
            var user = _userRepository.Get(model.UserEmailAddress);

            var bookReview = new BookReview { BookId = model.BookId, User = user, Title = model.Title, Content = model.Content, Confirmed = false };

            _repository.Add(bookReview);

            return bookReview;
        }

        public void AddBookReviewRate(int bookReviewId, string userEmailAddress, bool value)
        {
            var user = _userRepository.Get(userEmailAddress);

            var bookReviewRate = _repository.GetBookReviewRate(bookReviewId, userEmailAddress);

            if (bookReviewRate == null)
            {
                bookReviewRate = new BookReviewRate { BookReviewId = bookReviewId, User = user, Value = value };
                _repository.AddBookReviewRate(bookReviewRate);
            }
            else
            {
                bookReviewRate.Value = value;
            }
        }

        public void DeleteBookReviewRate(int bookReviewId, string userEmailAddress)
        {
            BookReviewRate bookReviewRate = _repository.GetBookReviewRate(bookReviewId, userEmailAddress);

            _repository.DeleteBookReviewRate(bookReviewRate);
        }

        public new ReviewDto Get(int id)
        {
            var review = Mapper.Map<ReviewDto>(_repository.Get(id));

            if(review != null)
            {                
                review.Rating = _repository.GetBookReviewRating(id);
            }

            return review;
        }

        public new IEnumerable<ReviewDto> GetList()
        {
            var reviews = Mapper.Map<IEnumerable<ReviewDto>>(_repository.GetList());

            foreach(var review in reviews)
            {
                review.Rating = _repository.GetBookReviewRating(review.Id);
            }

            return reviews;
        }

        public RateDto GetBookReviewRating(int id)
        {
            return _repository.GetBookReviewRating(id);
        }

        public void ConfirmReview(int reviewId)
        {
            BookReview review = _repository.Get(reviewId);

            review.Confirmed = true;
        }
    }
}
