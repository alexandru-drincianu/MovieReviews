using Application.Reviews.Commands.AddReview;
using Application.Reviews.Queries.GetReviewById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web_MovieReviews.Dtos;

namespace Web_MovieReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ReviewsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewPutPostDto review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var command = _mapper.Map<CreateGenreCommand>(genre);
            //var created = await _mediator.Send(command);
            var created = await _mediator.Send(new AddReviewCommand
            {
                MovieId = review.MovieId,
                UserId = review.UserId,
                Rating = review.Rating,
                ReviewDescription = review.Description
            });
            var dto = _mapper.Map<ReviewGetDto>(created);

            return CreatedAtAction(nameof(GetReviewById), new { reviewId = created.Id }, dto);
        }

        [HttpGet]
        [Route("{reviewId}")]
        public async Task<IActionResult> GetReviewById(int reviewId)
        {
            var query = new GetReviewByIdQuery { Id = reviewId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<ReviewGetDto>(result);
            return Ok(mappedResult);
        }
    }
}
