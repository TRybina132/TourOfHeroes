using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace Presentation.Filters
{
    //  ᓚᘏᗢ Can be useful when we dealign with certian exceptionns
    //          that occurs during action
    //
    //  ᓚᘏᗢ Executes after exception occured?
    //
    //  ᓚᘏᗢ Also can implement IAsyncExceptionFilter if
    //          exception handling requires async operations
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment environment;

        public ExceptionFilter(IHostEnvironment environment)
        {
            this.environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            //  ᓚᘏᗢ What will be written to response
            int statusCode = (int)HttpStatusCode.InternalServerError;
            if (context.Exception is EntityNotFoundException)
                statusCode = (int)HttpStatusCode.NotFound;
            context.Result = new ContentResult
            {
                Content = context.Exception.Message,
                ContentType = "application/json",
                StatusCode = statusCode
            };
        }
    }
}
