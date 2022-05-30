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
        private readonly IActorRepository _actorRepository;
        public CreateMovieCommandHandler(IMovieRepository movieRepository, IGenreRepository genreRepository, IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _actorRepository = actorRepository;

        }
        public async Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie { Title = request.Title, Description = request.Description ,MoviePicture = request.MoviePicture, Genres = new List<Genre>(), Reviews = new List<Review>(), Actors = new List<Actor>() };
            foreach (var id in request.GenresIds)
            {
                var genre = await _genreRepository.GetById(id);
                movie.Genres.Add(genre);
            }
            foreach (var id in request.ActorsIds)
            {
                var actor = await _actorRepository.GetById(id);
                movie.Actors.Add(actor);
            }

            await _movieRepository.Add(movie);

            return movie;
        }
    }
}
