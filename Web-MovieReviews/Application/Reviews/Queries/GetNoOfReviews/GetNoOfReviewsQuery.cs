using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetNoOfReviews
{
    public class GetNoOfReviewsQuery : IRequest<List<RatingGroup>>
    {
        public int Id { get; set; }
    }
}
