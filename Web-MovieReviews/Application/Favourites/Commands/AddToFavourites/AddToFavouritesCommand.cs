using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Favourites.Commands.AddToFavourites
{
    public class AddToFavouritesCommand : IRequest<List<Movie>>
    {
        public Guid UserId { get; set; }
        public int MovieId { get; set; }
    }
}
