using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IBookService : IServiceBase<Book, AddBookModel, BookDto, int>
    {
        void AddBookGenres(Book book, ICollection<int> genreIds);
        void AddBookAuthors(Book book, ICollection<int> authorIds);

        void DeleteBookGenre(int bookId, int genreId);
    }
}
