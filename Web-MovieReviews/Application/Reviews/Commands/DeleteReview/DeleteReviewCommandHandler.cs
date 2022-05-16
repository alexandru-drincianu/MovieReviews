using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Unit>
    {
        private readonly IReviewRepository _repository;
        public DeleteReviewCommandHandler(IReviewRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
