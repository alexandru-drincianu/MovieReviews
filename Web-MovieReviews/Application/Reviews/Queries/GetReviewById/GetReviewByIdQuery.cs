using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQuery : IRequest<Review>
    {
        public int Id { get; set; }
    }
}
