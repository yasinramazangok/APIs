using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.Mediator.Commands.CastCommands;
using MovieApi.Application.Features.Mediator.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCastList()
        {
            var casts = await _mediator.Send(new GetCastQuery());
            return Ok(casts);
        }

        [HttpGet("GetCastById")]
        public async Task<IActionResult> GetCastById(int id)
        {
            var cast = await _mediator.Send(new GetCastByIdQuery(id));
            return Ok(cast);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCast(int id)
        {
            await _mediator.Send(new RemoveCastCommand(id));
            return Ok("Silme işlemi başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme işlemi başarılı!");
        }
    }
}
