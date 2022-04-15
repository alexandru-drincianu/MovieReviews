using AutoMapper;
using Domain.Entities;
using Web_MovieReviews.Dtos;

namespace Web_MovieReviews.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenreDto, Genre>()
                .ForMember(p => p.GenreName, opt => opt.MapFrom(s => s.GenreName))
                .ReverseMap();

            CreateMap<GenreGetDto, Genre>()
                .ForMember(p => p.GenreName, opt => opt.MapFrom(s => s.GenreName))
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ReverseMap();

        }
    }
}
