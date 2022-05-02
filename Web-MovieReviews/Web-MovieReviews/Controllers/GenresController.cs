using Application.Genres.Commands.CreateGenre;
using Application.Genres.Queries.GetGenreById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web_MovieReviews.Dtos;

namespace Web_MovieReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GenresController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] GenreDto genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var command = _mapper.Map<CreateGenreCommand>(genre);
            //var created = await _mediator.Send(command);
            var created = await _mediator.Send(new CreateGenreCommand { GenreName = genre.GenreName }); 
            var dto = _mapper.Map<GenreGetDto>(created);

            return CreatedAtAction(nameof(GetGenreById), new { genreId = created.Id }, dto);
        }

        [HttpGet]
        [Route("{genreId}")]
        public async Task<IActionResult> GetGenreById(int genreId)
        {
            var query = new GetGenreByIdQuery { Id = genreId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<GenreGetDto>(result);
            return Ok(mappedResult);
        }
    }
}
