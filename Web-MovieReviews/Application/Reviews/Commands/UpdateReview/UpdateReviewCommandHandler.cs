using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Review>
    {
        private readonly IReviewRepository _repository;
        public UpdateReviewCommandHandler(IReviewRepository repository)
        {
            _repository = repository;
        }
        public async Task<Review> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetById(request.Id);
            review.UserId = request.UserId;
            review.MovieId = request.MovieId;
            review.Rating = request.Rating;
            review.ReviewDescription = request.ReviewDescription;
            await _repository.Update(review);
            return review;
        }
    }
}
