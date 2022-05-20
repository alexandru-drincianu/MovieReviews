using Application.Reviews.Commands.AddReview;
using Application.Reviews.Commands.DeleteReview;
using Application.Reviews.Commands.UpdateReview;
using Application.Reviews.Queries.GetNoOfReviews;
using Application.Reviews.Queries.GetReviewById;
using Application.Reviews.Queries.GetReviews;
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

        [HttpGet]
        [Route("ratings/{movieId}")]
        public async Task<IActionResult> GetRatingNo(int movieId)
        {
            var query = new GetNoOfReviewsQuery() { Id = movieId };
            var result = await _mediator.Send(query);
                
            var mappedResult = _mapper.Map<List<RatingGroupDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewPutPostDto review)
        {
            var command = new UpdateReviewCommand()
            {
                Id = id,
                UserId = review.UserId,
                MovieId = review.MovieId,
                Rating = review.Rating,
                ReviewDescription = review.Description
            };
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<ReviewGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var command = new DeleteReviewCommand() { Id = id };
            var result = await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var query = new GetReviewsQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<IEnumerable<ReviewGetDto>>(result);
            return Ok(mappedResult);
        }
    }
}
