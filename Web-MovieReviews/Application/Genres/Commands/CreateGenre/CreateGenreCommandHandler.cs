using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Genre>
    {
        private readonly IGenreRepository _repository;
        public CreateGenreCommandHandler(IGenreRepository repository)
        {
            _repository = repository;
        }
        public async Task<Genre> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre { GenreName = request.GenreName };
            await _repository.Add(genre);
            return genre;
        }
    }
}
