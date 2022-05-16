using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<Movie>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MoviePicture { get; set; }
        public List<int> GenresIds { get; set; }
    }
}
