using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Shared.ErrorModels;

namespace Heathcare_Management_System.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next,ILogger<GlobalErrorHandlingMiddleware>logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
                if(context.Response.StatusCode==StatusCodes.Status404NotFound)
                {
                    context.Response.ContentType = "application/json";
                    var response = new ErrorDetails()
                    {
                        StatusCode=StatusCodes.Status404NotFound,
                        ErrorMessage=$"This endPoint{context.Request.Path} Not Found!!"
                    };
                    await context.Response.WriteAsJsonAsync(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                //1-return response staus code
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                //2-return response content type
                context.Response.ContentType= "application/json";
                //3-return response object
                var response = new ErrorDetails()
                {
                    //StatusCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage= ex.Message
                };
                response.StatusCode = ex switch

                {
                    NotFoundException=>StatusCodes.Status404NotFound,
                    _=>StatusCodes.Status500InternalServerError
                };
                context.Response.StatusCode = response.StatusCode;

                //4- return Response
                await context.Response.WriteAsJsonAsync(response);
            }

        }
    }
}
