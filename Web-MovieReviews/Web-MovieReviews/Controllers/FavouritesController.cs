using Application.Favourites.Commands.AddToFavourites;
using Application.Favourites.Commands.RemoveFromFavourites;
using Application.Favourites.Queries.GetFavourites;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web_MovieReviews.Dtos;

namespace Web_MovieReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public FavouritesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetFavouritesByUser(Guid userId)
        {
            var query = new GetFavouritesQuery() { UserId = userId };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<MovieGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("add")]
        public async Task<IActionResult> AddToFavourites([FromBody] AddRemoveFavouritesDto favourites)
        {
            var command = new AddToFavouritesCommand() { MovieId = favourites.MovieId, UserId = favourites.UserId };
            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<List<MovieGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> RemoveFromFavourites([FromBody] AddRemoveFavouritesDto favourites)
        {
            var command = new RemoveFromFavouritesCommand() { UserId = favourites.UserId, MovieId = favourites.MovieId };
            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<List<MovieGetDto>>(result);
            return Ok(mappedResult);
        }
    }
}
