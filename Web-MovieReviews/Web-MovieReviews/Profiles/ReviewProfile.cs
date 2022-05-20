using Application.Reviews.Queries.GetNoOfReviews;
using AutoMapper;
using Domain.Entities;
using Web_MovieReviews.Dtos;

namespace Web_MovieReviews.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewGetDto, Review>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.MovieId, opt => opt.MapFrom(s => s.MovieId))
                .ForMember(p => p.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForPath(p => p.User.Name, opt => opt.MapFrom(s => s.UserName))
                .ForMember(p => p.Rating, opt => opt.MapFrom(s => s.Rating))
                .ForMember(p => p.ReviewDescription, opt => opt.MapFrom(s => s.Description))
                .ReverseMap();
            CreateMap<RatingGroupDto, RatingGroup>()
                .ForMember(p => p.Rating, opt => opt.MapFrom(s => s.Rating))
                .ForMember(p => p.RatingNo, opt => opt.MapFrom(s => s.NoRating))
                .ReverseMap();
        }
    }
}
