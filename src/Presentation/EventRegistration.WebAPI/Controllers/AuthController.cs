using EventRegistration.Application.Features.Auth.Command.Register;
using EventRegistration.Application.Wrappers.ServiceResponses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistration.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ServiceResponse> Register(RegisterCommandRequest request)
        {
           var result= await mediator.Send(request);

            return new ServiceResponse(true, System.Net.HttpStatusCode.Created, "User created!");

        }
    }
}
