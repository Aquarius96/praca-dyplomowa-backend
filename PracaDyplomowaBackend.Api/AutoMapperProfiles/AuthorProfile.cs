using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
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
            CreateMap<Author, AuthorDto>();

            CreateMap<Author, BookAuthorDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => $"{src.Firstname} {src.Lastname}"));
        }
    }
}
