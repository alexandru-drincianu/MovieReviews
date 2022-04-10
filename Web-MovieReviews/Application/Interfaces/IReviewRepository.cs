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
        Task<Review> GetByUserOnMovie(int userId, int movieId);
        Task Add(Review review);
        Task Update(Review review);
        Task Delete(int id);
    }
}
