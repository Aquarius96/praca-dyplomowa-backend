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
         
    }
}
