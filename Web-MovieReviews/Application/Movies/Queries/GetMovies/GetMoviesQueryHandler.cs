using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Queries.GetMovies
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _repository;
        public GetMoviesQueryHandler(IMovieRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
