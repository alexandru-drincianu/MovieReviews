using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actors.Commands.CreateActor
{
    public class CreateActorCommand : IRequest<Actor>
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
