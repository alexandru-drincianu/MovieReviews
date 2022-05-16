using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Commands.CreateMovie
{
    internal class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Movie>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        public CreateMovieCommandHandler(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;

        }
        public async Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie { Title = request.Title, Description = request.Description ,MoviePicture = request.MoviePicture, Genres = new List<Genre>(), Reviews = new List<Review>()};
            foreach (var id in request.GenresIds)
            {
                var genre = await _genreRepository.GetById(id);
                movie.Genres.Add(genre);
            }
            await _movieRepository.Add(movie);

            return movie;
        }
    }
}
