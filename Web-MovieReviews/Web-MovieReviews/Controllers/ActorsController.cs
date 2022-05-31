using Application.Actors.Commands.CreateActor;
using Application.Actors.Queries.GetActorById;
using Application.Actors.Queries.GetAllActors;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web_MovieReviews.Dtos;

namespace Web_MovieReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ActorsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] ActorPostPutDto actor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var command = _mapper.Map<CreateGenreCommand>(genre);
            //var created = await _mediator.Send(command);
            var created = await _mediator.Send(new CreateActorCommand() { Image = actor.Image, Name = actor.Name});
            var dto = _mapper.Map<ActorGetDto>(created);

            return CreatedAtAction(nameof(GetActorById), new { actorId = created.Id }, dto);
        }

        [HttpGet]
        [Route("{actorId}")]
        public async Task<IActionResult> GetActorById(int actorId)
        {
            var query = new GetActorByIdQuery { Id = actorId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<ActorGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllActorsQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<ActorGetDto>>(result);
            return Ok(mappedResult);
        }
    }
}
