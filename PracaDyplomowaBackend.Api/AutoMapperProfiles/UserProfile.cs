using AutoMapper;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using System;

namespace PracaDyplomowaBackend.Api.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterModel, User>();
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRole.Role.Name))
                .ForMember(dest => dest.AddedCommentsAmount, opt => opt.MapFrom(src => src.AuthorComments.Count))
                .ForMember(dest => dest.AddedReviewsAmount, opt => opt.MapFrom(src => src.BookReviews.Count))
                .ForMember(dest => dest.FavoriteAuthorsAmount, opt => opt.MapFrom(src => src.FavoriteAuthors.Count))
                .ForMember(dest => dest.FavoriteBooksAmount, opt => opt.MapFrom(src => src.FavoriteBooks.Count))
                .ForMember(dest => dest.ReadBooksAmount, opt => opt.MapFrom(src => src.ReadBooks.Count));
        }        
    }
}
