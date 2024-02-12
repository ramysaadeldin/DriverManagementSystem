using DriverManagementSystem.Common;
using DriverManagementSystem.Domain.Exceptions;
using NLog;
using System.Text.Json;

namespace DriverManagementSystem.API.Middlewares;
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new ApiResponse<object>(ex.Message, false), options));
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An unhandled exception occurred");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new ApiResponse<object>("An unexpected error occurred. Please try again later.", false), options));

        }
    }
}
