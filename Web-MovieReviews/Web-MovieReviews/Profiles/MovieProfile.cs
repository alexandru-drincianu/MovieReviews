using AutoMapper;
using Domain.Entities;
using Web_MovieReviews.Dtos;

namespace Web_MovieReviews.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieGetDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(p => p.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(p => p.MoviePicture, opt => opt.MapFrom(s => s.MoviePicture))
                .ReverseMap();

            CreateMap<MoviePutPostDto, Movie>()
                .ForMember(p => p.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(p => p.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(p => p.MoviePicture, opt => opt.MapFrom(s => s.MoviePicture))
                .ReverseMap();

            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Review, ReviewGetDto>().ReverseMap();
        }

    }
}
