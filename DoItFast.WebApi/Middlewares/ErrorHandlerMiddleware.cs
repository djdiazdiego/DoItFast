using DoItFast.Application.Exceptions;
using DoItFast.Application.Extensions;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Wrappers;
using Newtonsoft.Json;
using System.Net;

namespace DoItFast.WebApi.Middlewares
{
    /// <summary>
    /// Catch flow errors.
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                IBaseResponse responseModel = exception is ValidationException validationException ?
                    new ValidationResponse(exception.Message, validationException) :
                    new Response<string>()
                    {
                        Succeeded = false,
                        Message = exception.Message,
                        Errors = exception.GetAllMessages().ToList()
                    };


                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = exception switch
                {
                    // custom application error
                    ApiException => (int)HttpStatusCode.BadRequest,
                    // custom validation error
                    ValidationException => (int)HttpStatusCode.UnprocessableEntity,
                    // unhandled error
                    _ => (int)HttpStatusCode.InternalServerError
                };

                var result = JsonConvert.SerializeObject(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
