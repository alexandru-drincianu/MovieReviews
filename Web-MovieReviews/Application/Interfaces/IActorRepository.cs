using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IActorRepository
    {
        Task<Actor> GetById(int id);
        Task Add(Actor actor);
    }
}
