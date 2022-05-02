using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Commands.AddReview
{
    public class AddReviewCommand : IRequest<Review>
    {
        public Guid UserId { get; set; }
        public int MovieId { get; set; }
        public double Rating { get; set; }
        public string ReviewDescription { get; set; }
    }
}
