using FluentValidation;
using System.Net;
using System.Text.Json;

namespace InvestorService.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); // Continue request pipeline
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            object resultObj;

            if (exception is ValidationException validationException)
            {
                code = HttpStatusCode.BadRequest; // 400
                resultObj = new
                {
                    errors = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                };
            }
            else if (exception is ArgumentException)
            {
                code = HttpStatusCode.BadRequest;
                resultObj = new { error = exception.Message };
            }
            else if (exception is KeyNotFoundException)
            {
                code = HttpStatusCode.NotFound;
                resultObj = new { error = exception.Message };
            }
            else
            {
                resultObj = new { error = "An unexpected error occurred" };
            }

            var result = JsonSerializer.Serialize(resultObj);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }

}
