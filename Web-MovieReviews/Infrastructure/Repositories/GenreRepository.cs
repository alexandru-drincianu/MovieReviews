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
    public class GenreRepository : IGenreRepository
    {

        private readonly AppDbContext _context;
        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var genre = _context.Genres.Find(id);
            if (genre != null)
                _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            var genres = _context.Genres
                .Include(x => x.Movies)
                .ToListAsync();
            return await genres;
        }

        public async Task<Genre> GetById(int id)
        {
            var genre = _context.Genres
                .Include(g => g.Movies)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return await genre;
        }

        public async Task Update(Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
