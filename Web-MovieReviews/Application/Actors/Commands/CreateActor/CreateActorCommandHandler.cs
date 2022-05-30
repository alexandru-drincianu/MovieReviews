using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actors.Commands.CreateActor
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Actor>
    {
        private readonly IActorRepository _repository;
        public CreateActorCommandHandler(IActorRepository repository)
        {
            _repository = repository;
        }
        public async Task<Actor> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = new Actor() { Image = request.Image, Name = request.Name };
            await _repository.Add(actor);
            return actor;
        }
    }
}
