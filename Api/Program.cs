using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

{
    builder.RegisterBuildServices();
    builder.RegisterScopedServices();
    builder.RegisterSingletonServices();
}

var app = builder.Build();

{
    var logger = app.Services.GetService<ILogger<Program>>();

    if (logger is null)
    {
        throw new ArgumentNullException(nameof(logger));
    }

    app.ApplyMigrations(logger);
    app.RegisterMiddlewares(logger);
    app.RegisterEndpoints(logger);
}

app.Run();
