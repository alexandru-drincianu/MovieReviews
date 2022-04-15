using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQuery : IRequest<Movie>
    {
        public int Id { get; set; }
    }
}
