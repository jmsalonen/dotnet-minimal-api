using Api.Services.DeviceService.Application.Actions;
using Api.Services.DeviceService.Infrastructure.DbContexts;
using Api.Services.DeviceService.Infrastructure.Repositories;
using Api.Services.UserService.Application.Actions;
using Api.Services.UserService.Infrastructure.DbContexts;
using Api.Services.UserService.Infrastructure.Repositories;

namespace Api.Extensions;

public static class Configuration
{
    public static void RegisterBuildServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();
    }

    public static void RegisterSingletonServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDeviceDBContextFactory, DeviceDBContextFactory>();
        builder.Services.AddScoped<IUserDBContextFactory, UserDBContextFactory>();
    }

    public static void RegisterScopedServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDeviceActions, DeviceActions>();
        builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();

        builder.Services.AddScoped<IUserActions, UserActions>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}
