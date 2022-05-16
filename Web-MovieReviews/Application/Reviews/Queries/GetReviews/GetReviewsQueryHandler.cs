using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetReviews
{
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, IEnumerable<Review>>
    {
        private readonly IReviewRepository _repository;
        public GetReviewsQueryHandler(IReviewRepository repository)
        {
            _repository = repository;   
        }
        public async Task<IEnumerable<Review>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
