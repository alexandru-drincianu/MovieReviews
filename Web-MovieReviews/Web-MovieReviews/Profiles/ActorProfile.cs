using AutoMapper;
using Domain.Entities;
using Web_MovieReviews.Dtos;

namespace Web_MovieReviews.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorPostPutDto>()
                .ForMember(p => p.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(p => p.Image, opt => opt.MapFrom(s => s.Image))
                .ReverseMap();

            CreateMap<Actor, ActorGetDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(p => p.Image, opt => opt.MapFrom(s => s.Image))
                .ReverseMap();
        }
    }
}
