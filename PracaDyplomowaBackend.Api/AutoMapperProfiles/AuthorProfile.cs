using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Library;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {            
            CreateMap<AddAuthorModel, Author>();
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Firstname} {src.Lastname}"))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToString("dd MMMM yyyy")));

            CreateMap<Author, BookAuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Firstname} {src.Lastname}"));

            CreateMap<AuthorRate, AuthorRateDto>();
        }
    }
}
