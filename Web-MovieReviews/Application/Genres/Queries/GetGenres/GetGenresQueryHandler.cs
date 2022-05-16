using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Genres.Queries.GetGenres
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, IEnumerable<Genre>>
    {
        private readonly IGenreRepository _repository;
        public GetGenresQueryHandler(IGenreRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Genre>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
