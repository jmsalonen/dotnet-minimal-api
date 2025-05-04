namespace Api.Extensions;

public static class MiddleWares
{
    public static void RegisterMiddlewares(this WebApplication app, ILogger logger)
    {
        logger.LogInformation("Registering middlewares...");
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger().UseSwaggerUI();
        }

        app.UseHttpsRedirection();
    }
}
