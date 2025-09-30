using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EventRegistration.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex) 
            { 
                await
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception) 
        {
            int statusCode = GetStatusCode(exception); 
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,//case
                NotFoundException => StatusCodes.Status400BadRequest,//case
                ValidationException => StatusCodes.Status422UnprocessableEntity,//case
                _ => StatusCodes.Status500InternalServerError //default 
            };
    }
}
