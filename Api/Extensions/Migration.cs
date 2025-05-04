using Api.Services.DeviceService.Infrastructure.DbContexts;
using Api.Services.UserService.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class Migration
{
    public static void ApplyMigrations(this WebApplication app, ILogger logger)
    {
        logger.LogInformation("Applying migrations...");
        using var scope = app.Services.CreateScope();

        logger.LogInformation("Migrate DeviceDBContext");
        var deviceFactory = scope.ServiceProvider.GetRequiredService<IDeviceDBContextFactory>();
        deviceFactory.CreateDbContext().Database.Migrate();

        logger.LogInformation("Migrate UserDBContext");
        var userFactory = scope.ServiceProvider.GetRequiredService<IUserDBContextFactory>();
        userFactory.CreateDbContext().Database.Migrate();

        logger.LogInformation("Migrations applied!");
    }
}
