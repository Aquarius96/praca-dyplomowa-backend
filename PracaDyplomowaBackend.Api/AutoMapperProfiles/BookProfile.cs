using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Library;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
   public class BookProfile : Profile
    {
        public BookProfile()
        {           
            CreateMap<AddBookModel, Book>();
            CreateMap<Book, BookDto>();

            CreateMap<Book, LibraryBookDto>();            
            CreateMap<Book, ReadBookDto>().AfterMap((src, dest) =>
            {
                dest.Finished = src.Added;
            });           
        }
    }
}
