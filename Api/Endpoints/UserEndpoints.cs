using Api.Services.UserService.Application.Actions;
using Api.Services.UserService.Infrastructure.Models;

namespace Api.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/v1/users");

        group.MapGet(
            "",
            async (ILogger<UserActions> logger, IUserActions userActions) =>
            {
                try
                {
                    var result = await userActions.GetUsers();
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
            async (ILogger<UserActions> logger, IUserActions userActions, int id) =>
            {
                try
                {
                    var result = await userActions.GetUser(id);
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
            async (ILogger<UserActions> logger, IUserActions userActions, User user) =>
            {
                try
                {
                    await userActions.AddUser(user);
                    return Results.Created("", user);
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
            async (ILogger<UserActions> logger, IUserActions userActions, int id, User user) =>
            {
                try
                {
                    await userActions.UpdateUser(user);
                    return Results.NoContent();
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
            async (ILogger<UserActions> logger, IUserActions userActions, int id) =>
            {
                try
                {
                    await userActions.DeleteUser(id);
                    return Results.NoContent();
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
