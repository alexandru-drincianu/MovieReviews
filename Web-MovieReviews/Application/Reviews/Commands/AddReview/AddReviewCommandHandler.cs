using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Commands.AddReview
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, Review>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMovieRepository _movieRepository;
        public AddReviewCommandHandler(IReviewRepository reviewRepository, UserManager<User> userManager, IMovieRepository movieRepository)
        {
            _reviewRepository = reviewRepository;
            _userManager = userManager;
            _movieRepository = movieRepository; 
        }
        public async Task<Review> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == request.UserId);
            var movie = await _movieRepository.GetById(request.MovieId);
            var review = new Review()
            {
                UserId = request.UserId,
                User = user,
                Movie = movie,
                MovieId = request.MovieId,
                Rating = request.Rating,
                ReviewDescription = request.ReviewDescription,
            };

            await _reviewRepository.Add(review);
            return review;
        }
    }
}
