using AutoMapper;
using Domain.Entities;
using Web_MovieReviews.Dtos;

namespace Web_MovieReviews.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ReverseMap();
        }
    }
}
