using EventRegistration.Application.Features.Events.Command.CreateCommand;
using EventRegistration.Application.Features.Events.Command.DeleteCommand;
using EventRegistration.Application.Features.Events.Command.UpdateCommand;
using EventRegistration.Application.Features.Events.Query;
using EventRegistration.Application.Wrappers.ServiceResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [Authorize]
        public async Task<ServiceResponseWithData<IList<GetAllEventsQueryResponse>>> GetAllEvents()
        {
            var response=await mediator.Send(new GetAllEventsQueryRequest());
            return new ServiceResponseWithData<IList<GetAllEventsQueryResponse>>(response,true,HttpStatusCode.OK,"All events!");

        }
        [HttpPost]
        
        public async Task<ServiceResponse> CreateEvent(CreateEventCommandRequest command)
        {
            var result = await mediator.Send(command);
            return new ServiceResponse();

            //if (!result.isSuccess) return BadRequest(new { message = result.Message });

            //return Ok(new { message = result.Message });
        }
        [HttpPut]
        public async Task<ServiceResponse> UpdateEvent(UpdateEventCommandRequest command)
        {
            var result = await mediator.Send(command);
            return new ServiceResponse();
        }   
        [HttpDelete]
        public async Task<ServiceResponse> DeleteEvent([FromQuery]DeleteEventCommandRequest command) 
        {
           var result= await mediator.Send(command);
            return new ServiceResponse();
            //if (!result.isSuccess) return BadRequest(new {message= result.Message });

            //return Ok(new { message = result.Message });
        }   

    }
}
