using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Models.Models.Genre;
using PracaDyplomowaBackend.Models.ModelsDto.Genre;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Service.Services
{
    public class GenreService : ServiceBase<Genre, AddGenreModel, GenreDto, int>, IGenreService
    {
        public GenreService(IGenreRepository repository) : base(repository)
        {
        }
    }
}
