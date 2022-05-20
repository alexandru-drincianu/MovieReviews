using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetNoOfReviews
{
    public class GetNoOfReviewsQueryHandler : IRequestHandler<GetNoOfReviewsQuery, List<RatingGroup>>
    {
        private readonly IReviewRepository reviewRepository;
        public GetNoOfReviewsQueryHandler(IReviewRepository repository)
        {
            reviewRepository = repository;
        }
        public async Task<List<RatingGroup>> Handle(GetNoOfReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await reviewRepository.GetReviewsByMovie(request.Id);
            var reviewsGrouped = reviews.GroupBy(r => r.Rating);
            var ratingsNo = new List<RatingGroup>();
            for (int i = 1; i <= 5; i++)
            {
                ratingsNo.Add(new RatingGroup() { Rating = i });
            }
            foreach (var review in reviewsGrouped)
            {
                ratingsNo.ElementAt(Convert.ToInt32(review.Key) - 1).RatingNo = review.Count();
            }
            return ratingsNo;
        }
    }
}
