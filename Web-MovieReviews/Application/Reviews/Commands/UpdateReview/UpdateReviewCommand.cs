using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest<Review>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int MovieId { get; set; }
        public double Rating { get; set; }
        public string ReviewDescription { get; set; }
    }
}
