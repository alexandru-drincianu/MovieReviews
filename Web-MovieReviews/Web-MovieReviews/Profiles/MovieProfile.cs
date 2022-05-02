﻿using AutoMapper;
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
                .ReverseMap();

            CreateMap<MoviePutPostDto, Movie>()
                .ForMember(p => p.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(p => p.Description, opt => opt.MapFrom(s => s.Description))
                .ReverseMap();

            CreateMap<Genre, GenreDto>();
            //CreateMap<Review, ReviewDto>();
        }

    }
}