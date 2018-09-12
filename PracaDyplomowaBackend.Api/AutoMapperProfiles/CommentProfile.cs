using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<AuthorComment, CommentDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => Mapper.Map<CommentAuthorDto>(src.User)));

            CreateMap<BookComment, CommentDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => Mapper.Map<CommentAuthorDto>(src.User)));

            CreateMap<User, CommentAuthorDto>();
        }
    }
}
