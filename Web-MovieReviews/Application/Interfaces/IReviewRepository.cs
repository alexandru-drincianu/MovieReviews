using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsByMovie(int movieId);
        Task<Review> GetByUserOnMovie(Guid userId, int movieId);
        Task<Review> GetById(int id);
        Task Add(Review review);
        Task Update(Review review);
        Task Delete(int id);
    }
}
