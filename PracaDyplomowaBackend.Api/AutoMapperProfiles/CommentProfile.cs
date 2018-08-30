using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<AuthorComment, CommentDto>()
                .ForMember(dest => dest.UserEmailAddress, opt => opt.MapFrom(src => src.User.EmailAddress));
        }
    }
}
