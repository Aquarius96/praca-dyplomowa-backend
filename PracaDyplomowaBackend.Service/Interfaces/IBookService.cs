using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IBookService : IServiceBase<Book, AddBookModel, BookDto, int>
    {
        void AddBookGenre(int bookId, int genreId);
        void AddBookGenres(Book book, ICollection<int> genreIds);
        void AddBookAuthors(Book book, ICollection<int> authorIds);
        void AddBookComment(int bookId, string userEmailAddress, string content);        
        void AddBookRate(int bookId, string userEmailAddress, int value);
        void AddImage(int bookId, string imageUrl);

        void DeleteBookGenre(int bookId, int genreId);
        void DeleteBookComment(int id);
        void DeleteBookRate(int bookId, string userEmailAddress);
        
        RateDto GetBookRating(int bookId);
    }
}
