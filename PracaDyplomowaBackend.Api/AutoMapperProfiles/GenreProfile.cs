using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Models.Models.Genre;
using PracaDyplomowaBackend.Models.ModelsDto.Genre;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<AddGenreModel, Genre>();
            CreateMap<Genre, GenreDto>();
        }
    }
}
