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
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;
        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review != null)
                _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<Review> GetByUserOnMovie(int userId, int movieId) 
        { 
            return await _context.Reviews
                .FirstOrDefaultAsync(review => review.UserId == userId && review.MovieId == movieId);
        }

        public async Task<IEnumerable<Review>> GetReviewsByMovie(int movieId)
        {
            return await _context.Reviews.Where(review => review.MovieId == movieId).ToListAsync();
        }

        public async Task Update(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
