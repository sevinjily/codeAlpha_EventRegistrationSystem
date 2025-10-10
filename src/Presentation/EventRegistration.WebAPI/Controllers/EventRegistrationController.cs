using EventRegistration.Application.Features.EventRegistrations.Command;
using EventRegistration.Application.Features.Events.Command.CreateCommand;
using EventRegistration.Application.Wrappers.ServiceResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistration.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventRegistrationController : ControllerBase
    {
        private readonly IMediator mediator;

        public EventRegistrationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<ServiceResponse> RegisterForEvent([FromQuery]CreateEventRegistrationCommandRequest request)
        {
            var result = await mediator.Send(request);
            return new ServiceResponse(true,System.Net.HttpStatusCode.Created,"User registered for event successfully!");


        }
    }
}
