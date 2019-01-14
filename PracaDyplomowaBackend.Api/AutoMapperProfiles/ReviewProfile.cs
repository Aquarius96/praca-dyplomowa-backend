using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using PracaDyplomowaBackend.Models.ModelsDto.User;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<AddBookReviewModel, BookReview>();

            CreateMap<BookReview, ReviewDto>()
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => Mapper.Map<LibraryBookDto>(src.Book)))
                .ForMember(dest => dest.ReviewAuthor, opt => opt.MapFrom(src => Mapper.Map<BookReviewAuthorDto>(src.User)));

            CreateMap<BookReview, BookReviewDto>()
                .ForMember(dest => dest.ReviewAuthor, opt => opt.MapFrom(src => Mapper.Map<BookReviewAuthorDto>(src.User)));

            CreateMap<User, BookReviewAuthorDto>();

            CreateMap<BookReviewRate, ReviewRateDto>();                
        }
    }
}
