using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actors.Queries.GetAllActors
{
    public class GetAllActorsQuery : IRequest<List<Actor>>
    {
    }
}
