using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using CourseOnline.Application.Exceptions;

namespace CourseOnline.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ExceptionHandlerAsync(context,ex,_logger);
            }
        }

        private async Task ExceptionHandlerAsync(HttpContext context, Exception ex, ILogger<ErrorHandlerMiddleware> logger)
        {
            object errors = null;
            switch (ex)
            {
                case CustomException<Object> ce:
                    logger.LogError(ex, "ErrorHandlerMiddleware");
                    errors = ce.Response;
                    context.Response.StatusCode = (int)ce.StatusCode; 
                    break;
                case Exception e:
                    logger.LogError(ex, "Error Service");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
                default:
                    break;
            }

            context.Response.ContentType = "application/json";
            if(errors != null)
            {
                var result = JsonSerializer.Serialize(errors);
                await context.Response.WriteAsync(result);
            }
        }
    }
}

