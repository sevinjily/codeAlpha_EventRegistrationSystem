using Azure.Core;
using EventRegistration.Application.Features.Auth.Command.Login;
using EventRegistration.Application.Features.Auth.Command.RefreshToken;
using EventRegistration.Application.Features.Auth.Command.Register;
using EventRegistration.Application.Features.Auth.Command.Revoke;
using EventRegistration.Application.Features.Auth.Command.RevokeAll;
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
        [HttpPost]
        public async Task<ServiceResponseWithData<LoginCommandResponse>> Login(LoginCommandRequest request)
        {
            var result = await mediator.Send(request);

            return new ServiceResponseWithData<LoginCommandResponse>(result,true, System.Net.HttpStatusCode.Created, "User login successfully!");

        }

        [HttpPost]
        public async Task<ServiceResponseWithData<RefreshTokenCommandResponse>> RefreshToken(RefreshTokenCommandRequest request)
        {
            var result = await mediator.Send(request);

            return new ServiceResponseWithData<RefreshTokenCommandResponse>(result, true, System.Net.HttpStatusCode.Created, "User login successfully!");

        }
        [HttpPost]
        public async Task<ServiceResponse> Revoke(RevokeCommandRequest request)
        {
             await mediator.Send(request);

            return new ServiceResponse(true, System.Net.HttpStatusCode.Created, "User logout!");

        }
        [HttpPost]
        public async Task<ServiceResponse> RevokeAll()
        {
             await mediator.Send(new RevokeAllCommandRequest());

            return new ServiceResponse(true, System.Net.HttpStatusCode.Created, "All users logout!");

        }
    }
}
