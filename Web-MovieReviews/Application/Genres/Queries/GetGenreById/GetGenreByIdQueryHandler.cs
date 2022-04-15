using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Genres.Queries.GetGenreById
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Genre>
    {
        private readonly IGenreRepository _repository;
        public GetGenreByIdQueryHandler(IGenreRepository repository)
        {
            _repository = repository;
        }
        public async Task<Genre> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var genre = await _repository.GetById(request.Id);
            return genre;
        }
    }
}
