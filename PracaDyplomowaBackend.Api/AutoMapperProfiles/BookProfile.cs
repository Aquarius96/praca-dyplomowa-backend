using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
   public class BookProfile : Profile
    {
        public BookProfile()
        {           
            CreateMap<AddBookModel, Book>();
            CreateMap<Book, BookDto>();
        }
    }
}
