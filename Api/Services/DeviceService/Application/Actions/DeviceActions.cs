using Api.Services.DeviceService.Infrastructure.Models;
using Api.Services.DeviceService.Infrastructure.Repositories;

namespace Api.Services.DeviceService.Application.Actions;

public interface IDeviceActions
{
    Task<List<Device>> GetDevices();

    Task<Device?> GetDevice(string id);

    Task AddDevice(Device device);

    Task UpdateDevice(Device device);

    Task DeleteDevice(string id);
}

public class DeviceActions(ILogger<DeviceActions> logger, IDeviceRepository deviceRepository)
    : IDeviceActions
{
    private readonly ILogger<DeviceActions> _logger = logger;
    private readonly IDeviceRepository _deviceRepository = deviceRepository;

    public async Task<List<Device>> GetDevices()
    {
        try
        {
            _logger.LogInformation("Retrieving devices...");

            return await Task.FromResult(_deviceRepository.GetAllAsync().Result);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task<Device?> GetDevice(string id)
    {
        try
        {
            _logger.LogInformation("Retrieving device...");

            return await Task.FromResult(_deviceRepository.GetByIdAsync(id).Result);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task AddDevice(Device device)
    {
        try
        {
            _logger.LogInformation("Adding device...");

            await _deviceRepository.AddAsync(device);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task UpdateDevice(Device device)
    {
        try
        {
            _logger.LogInformation("Updating device...");

            await _deviceRepository.UpdateAsync(device);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task DeleteDevice(string id)
    {
        try
        {
            _logger.LogInformation("Deleting device...");

            await _deviceRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }
}
