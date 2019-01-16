using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {           
            CreateMap<AddBookModel, Book>();
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Released, opt => opt.MapFrom(src => src.Released.ToString("dd MMMM yyyy", new CultureInfo("PL"))));

            CreateMap<Genre, BookGenreDto>();
                        
            CreateMap<Book, LibraryBookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<BookAuthorDto>>(src.BookAuthors.Select(x => x.Author))))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<BookGenreDto>>(src.BookGenres.Select(x => x.Genre))));

            CreateMap<Book, AuthorBookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<BookAuthorDto>>(src.BookAuthors.Select(x => x.Author))))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<BookGenreDto>>(src.BookGenres.Select(x => x.Genre))))
                .ForMember(dest => dest.Released, opt => opt.MapFrom(src => src.Released.ToString("dd MMMM yyyy", new CultureInfo("PL"))));

            CreateMap<Book, ReadBookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<BookAuthorDto>>(src.BookAuthors.Select(x => x.Author))))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<BookGenreDto>>(src.BookGenres.Select(x => x.Genre))))
                .ForMember(dest => dest.Finished, opt => opt.MapFrom(src => src.ReadBooks.FirstOrDefault(book => book.BookId == src.Id).Finished.ToString("dd MMMM yyyy", new CultureInfo("PL"))));

            CreateMap<BookRate, BookRateDto>();

        }
    }
}
