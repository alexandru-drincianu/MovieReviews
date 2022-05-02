using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Queries.SearchForMovie
{
    public class SearchForMovieQueryHandler : IRequestHandler<SearchForMovieQuery, List<Movie>>
    {
        private readonly IMovieRepository _repository;
        public SearchForMovieQueryHandler(IMovieRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Movie>> Handle(SearchForMovieQuery request, CancellationToken cancellationToken)
        {
            var movies = await _repository.GetAll();
            var filteredMovies = movies.Where(x => x.Title.Contains(request.Name)).ToList();
            return filteredMovies;
        }
    }
}
