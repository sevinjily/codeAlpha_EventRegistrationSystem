using EventRegistration.Application.Features.Events.Command.CreateCommand;
using EventRegistration.Application.Features.Events.Command.DeleteCommand;
using EventRegistration.Application.Features.Events.Command.UpdateCommand;
using EventRegistration.Application.Features.Events.Query;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistration.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator mediator;

        public EventController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var response=await mediator.Send(new GetAllEventsQueryRequest());

            if (!response.isSuccess) return BadRequest(new { message = response.Message });

            return Ok(new { message = response.Message });
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventCommandRequest command)
        {
            var result = await mediator.Send(command);
            if (!result.isSuccess) return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEvent(UpdateEventCommandRequest command)
        {
            var result = await mediator.Send(command);
            if (!result.isSuccess) return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEvent([FromQuery]DeleteCommandRequest command)
        {
           var result= await mediator.Send(command);
            if (!result.isSuccess) return BadRequest(new {message= result.Message });

            return Ok(new { message = result.Message });
        }   

    }
}
