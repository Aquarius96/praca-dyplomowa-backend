using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IReviewRepository : IRepositoryBase<BookReview, int>
    {
        void AddBookReviewRate(BookReviewRate bookReviewRate);
        void DeleteBookReviewRate(BookReviewRate bookReviewRate);

        BookReviewRate GetBookReviewRate(int bookReviewId, string userEmailAddress);
        RateDto GetBookReviewRating(int bookReviewId);
        IEnumerable<BookReviewDto> GetBookReviews(int bookId);
    }
}
