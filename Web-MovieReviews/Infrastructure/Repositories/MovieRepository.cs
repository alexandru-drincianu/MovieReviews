using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
                _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movies = _context.Movies
                .Include(_m => _m.Genres)
                .Include(_m => _m.Reviews)
                .ThenInclude(r => r.User)
                .Include(_m => _m.Actors)
                .ToListAsync();
            return await movies;
        }

        public async Task<Movie> GetById(int id)
        {
            var movie = _context.Movies
                .Include(_m => _m.Genres)
                .Include(_m => _m.Reviews)
                .ThenInclude(r => r.User)
                .Include(_m => _m.Actors)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
            return await movie;
        }

        public async Task Update(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
