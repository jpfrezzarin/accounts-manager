using System.Net;
using AccountsManager.Application.Common;
using AccountsManager.Domain.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AccountsManager.Api.Middlewares;

public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) : IMiddleware
{    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException e)
        {
            await HandleException(HttpStatusCode.NotFound, context, e.Message);
        }
        catch (AccountsManagerException e)
        {
            await HandleException(HttpStatusCode.UnprocessableEntity, context, e.Message);
        }
        catch (Exception e)
        {
            await HandleException(context, e);
        }
    }
    
    private async Task HandleException(HttpStatusCode statusCode, HttpContext context, string message)
    {
        logger.LogWarning("Expected error handled: {Message}", message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(
            JsonConvert.SerializeObject(new ErrorViewModel(message), GetJsonSerializerSettings()));
    }
    
    private async Task HandleException(HttpContext context, Exception exception)
    {
        logger.LogError(exception, "Unexpected error handled");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsync(
            JsonConvert.SerializeObject(new ErrorViewModel("An unexpected error occurs. Sorry for that! :("), GetJsonSerializerSettings()));
    }

    private static JsonSerializerSettings GetJsonSerializerSettings()
    {
        return new JsonSerializerSettings 
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}