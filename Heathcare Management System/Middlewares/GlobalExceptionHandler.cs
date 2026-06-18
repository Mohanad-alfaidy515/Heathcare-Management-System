using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;
using System.Net;
using System.Text.Json;

namespace Heathcare_Management_System.Middlewares
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

            var errorDetails = new ErrorDetails
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ErrorMessage = "An internal server error occurred. Please try again later."
            };

            // Custom handling for specific exceptions can be added here
            if (exception is UnauthorizedAccessException)
            {
                errorDetails.StatusCode = (int)HttpStatusCode.Unauthorized;
                errorDetails.ErrorMessage = "Unauthorized access.";
            }

            httpContext.Response.StatusCode = errorDetails.StatusCode;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync(errorDetails, cancellationToken);

            return true;
        }
    }
}
