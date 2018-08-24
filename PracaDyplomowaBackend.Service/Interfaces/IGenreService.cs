using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Models.Models.Genre;
using PracaDyplomowaBackend.Models.ModelsDto.Genre;

namespace PracaDyplomowaBackend.Service.Interfaces
{
    public interface IGenreService : IServiceBase<Genre, AddGenreModel, GenreDto, int>
    {
    }
}
