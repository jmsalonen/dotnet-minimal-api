using Api.Services.DeviceService.Application.Actions;
using Api.Services.DeviceService.Infrastructure.Models;

namespace Api.Endpoints;

public static class DeviceEndpoints
{
    public static void MapDeviceEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/v1/devices");

        group.MapGet(
            "",
            async (ILogger<DeviceActions> logger, IDeviceActions deviceActions) =>
            {
                try
                {
                    var result = await deviceActions.GetDevices();
                    return Results.Ok(result);
                }
                catch (Exception e)
                {
                    logger.LogError("{Message}", e.Message);
                    return Results.Problem();
                }
            }
        );

        group.MapGet(
            "/{id}",
            async (ILogger<DeviceActions> logger, IDeviceActions deviceActions, string id) =>
            {
                try
                {
                    var result = await deviceActions.GetDevice(id);
                    return Results.Ok(result);
                }
                catch (Exception e)
                {
                    logger.LogError("{Message}", e.Message);
                    return Results.Problem();
                }
            }
        );

        group.MapPost(
            "",
            async (ILogger<DeviceActions> logger, IDeviceActions deviceActions, Device device) =>
            {
                try
                {
                    await deviceActions.AddDevice(device);
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    logger.LogError("{Message}", e.Message);
                    return Results.Problem();
                }
            }
        );

        group.MapPut(
            "/{id}",
            async (ILogger<DeviceActions> logger, IDeviceActions deviceActions, Device device) =>
            {
                try
                {
                    await deviceActions.UpdateDevice(device);
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    logger.LogError("{Message}", e.Message);
                    return Results.Problem();
                }
            }
        );

        group.MapDelete(
            "/{id}",
            async (ILogger<DeviceActions> logger, IDeviceActions deviceActions, string id) =>
            {
                try
                {
                    await deviceActions.DeleteDevice(id);
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    logger.LogError("{Message}", e.Message);
                    return Results.Problem();
                }
            }
        );
    }
}
