using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
   public class BookProfile : Profile
    {
        public BookProfile()
        {           
            CreateMap<AddBookModel, Book>();
            CreateMap<Book, BookDto>();                  

            CreateMap<Genre, BookGenreDto>();
            
            CreateMap<ReadBook, ReadBookDto>()
                .ForMember(dest => dest.Finished, opt => opt.MapFrom(src => src.Added))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<BookAuthorDto>>(src.Book.BookAuthors.Select(x => x.Author))))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<BookGenreDto>>(src.Book.BookGenres.Select(x => x.Genre))));

            CreateMap<BookReview, BookReviewDto>()
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => Mapper.Map<LibraryBookDto>(src.Book)))
                .ForMember(dest => dest.ReviewAuthor, opt => opt.MapFrom(src => Mapper.Map<BookReviewAuthorDto>(src.User)));                

            CreateMap<Book, LibraryBookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<BookAuthorDto>>(src.BookAuthors.Select(x => x.Author))))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<BookGenreDto>>(src.BookGenres.Select(x => x.Genre))));

            CreateMap<User, BookReviewAuthorDto>();
        }
    }
}
