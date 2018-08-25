using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<AuthorComment, CommentDto>().AfterMap((src, dest) =>
            {
                dest.UserEmailAddress = src.User.EmailAddress;
            });
        }
    }
}
