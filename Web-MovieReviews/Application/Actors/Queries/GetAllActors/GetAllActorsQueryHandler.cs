using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actors.Queries.GetAllActors
{
    public class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQuery, List<Actor>>
    {
        private readonly IActorRepository _repository;
        public GetAllActorsQueryHandler(IActorRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Actor>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
