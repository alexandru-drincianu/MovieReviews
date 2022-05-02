using Application.Movies.Commands.CreateMovie;
using Application.Movies.Queries.GetMovieById;
using Application.Movies.Queries.SearchForMovie;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web_MovieReviews.Dtos;

namespace Web_MovieReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public MoviesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MoviePutPostDto movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var command = _mapper.Map<CreateGenreCommand>(genre);
            //var created = await _mediator.Send(command);
            var created = await _mediator.Send(new CreateMovieCommand { Title = movie.Title, Description = movie.Description, GenresIds = movie.GenresIds} );
            var dto = _mapper.Map<MovieGetDto>(created);

            return CreatedAtAction(nameof(GetMovieById), new { movieId = created.Id }, dto);
        }

        [HttpGet]
        [Route("{movieId}")]
        public async Task<IActionResult> GetMovieById(int movieId)
        {
            var query = new GetMovieByIdQuery { Id = movieId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<MovieGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> SearchForMovies(string name)
        {
            var query = new SearchForMovieQuery { Name = name };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<List<MovieGetDto>>(result);
            return Ok(mappedResult);
        }
    }
}
