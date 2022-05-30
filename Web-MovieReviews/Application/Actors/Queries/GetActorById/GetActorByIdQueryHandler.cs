using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actors.Queries.GetActorById
{
    public class GetActorByIdQueryHandler : IRequestHandler<GetActorByIdQuery, Actor>
    {
        private readonly IActorRepository _repository;
        public GetActorByIdQueryHandler(IActorRepository repository)
        {
            _repository = repository;
        }
        public async Task<Actor> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
        {
            var actor = await _repository.GetById(request.Id);
            return actor;
        }
    }
}
