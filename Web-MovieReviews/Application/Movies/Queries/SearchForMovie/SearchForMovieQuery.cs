using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Queries.SearchForMovie
{
    public class SearchForMovieQuery : IRequest<List<Movie>>
    {
        public string Name { get; set; }
    }
}
