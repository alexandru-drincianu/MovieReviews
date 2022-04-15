using Domain.Entities;
using MediatR;

namespace Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<Genre>
    {
        public string GenreName { get; set; }
    }
}
