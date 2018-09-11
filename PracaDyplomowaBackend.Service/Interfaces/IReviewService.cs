using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IReviewService : IServiceBase<BookReview, AddBookReviewModel, ReviewDto, int>
    {
        void AddBookReviewRate(int bookReviewId, string userEmailAddress, bool value);
        void DeleteBookReviewRate(int bookReviewId, string userEmailAddress);
        RateDto GetBookReviewRating(int id);
    }
}
