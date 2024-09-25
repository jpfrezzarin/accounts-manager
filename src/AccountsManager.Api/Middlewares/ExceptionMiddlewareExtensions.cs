namespace AccountsManager.Api.Middlewares;

public static class ExceptionMiddlewareExtensions
{
    public static IServiceCollection AddHandlingExceptions(this IServiceCollection services)
    {
        return services.AddTransient<ExceptionMiddleware>();
    }

    public static void UseHandlingExceptions(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}