using Api.Endpoints;

namespace Api.Extensions;

public static class Router
{
    public static void RegisterEndpoints(this WebApplication app, ILogger logger)
    {
        logger.LogInformation("Registering endpoints...");

        var configuration = app.Services.GetService<IConfiguration>();

        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        var test = configuration["TEST"];

        app.MapGet("/", () => test);
        app.MapGet("/health", () => "Healthy");
        app.MapGet("/healthz", () => "Healthy");
        app.MapGet("/test", () => "new test endpoint!");

        UserEndpoints.MapUserEndpoints(app);
        DeviceEndpoints.MapDeviceEndpoints(app);
    }
}
