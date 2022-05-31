using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _context;
        public ActorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor> GetById(int id)
        {
            var actor = await _context.Actors
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return actor;
        }

        public async Task<List<Actor>> GetAll()
        {
            return await _context.Actors.ToListAsync();
        }
    }
}
