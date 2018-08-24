using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Author;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AddAuthorModel, Author>();
            CreateMap<Author, AuthorDto>();
        }
    }
}
