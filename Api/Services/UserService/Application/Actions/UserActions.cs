using Api.Services.UserService.Infrastructure.Models;
using Api.Services.UserService.Infrastructure.Repositories;

namespace Api.Services.UserService.Application.Actions;

public interface IUserActions
{
    Task<List<User>> GetUsers();

    Task<User?> GetUser(int id);

    Task AddUser(User user);

    Task UpdateUser(User user);

    Task DeleteUser(int id);
}

public class UserActions(ILogger<UserActions> logger, IUserRepository userRepository) : IUserActions
{
    private readonly ILogger<UserActions> _logger = logger;

    private readonly IUserRepository _userRepository = userRepository;

    public async Task<List<User>> GetUsers()
    {
        try
        {
            _logger.LogInformation("Retrieving users...");

            return await Task.FromResult(_userRepository.GetAllAsync().Result);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task<User?> GetUser(int id)
    {
        try
        {
            _logger.LogInformation("Retrieving user...");

            return await Task.FromResult(_userRepository.GetByIdAsync(id).Result);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task AddUser(User user)
    {
        try
        {
            _logger.LogInformation("Adding user...");

            await _userRepository.AddAsync(user);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task UpdateUser(User user)
    {
        try
        {
            _logger.LogInformation("Updating user...");

            await _userRepository.UpdateAsync(user);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task DeleteUser(int id)
    {
        try
        {
            _logger.LogInformation("Deleting user...");

            await _userRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }
}
