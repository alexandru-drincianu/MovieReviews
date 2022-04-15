using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private readonly IMovieRepository _repository;
        public GetMovieByIdQueryHandler(IMovieRepository repository)
        {
            _repository = repository;
        }
        public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _repository.GetById(request.Id);
            return movie;
        }
    }
}
