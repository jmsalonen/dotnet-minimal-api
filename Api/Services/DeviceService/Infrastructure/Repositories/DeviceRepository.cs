using Api.Services.DeviceService.Infrastructure.DbContexts;
using Api.Services.DeviceService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.DeviceService.Infrastructure.Repositories;

public interface IDeviceRepository
{
    Task<Device?> GetByIdAsync(string id);
    Task<List<Device>> GetAllAsync();
    Task AddAsync(Device device);
    Task UpdateAsync(Device device);
    Task DeleteAsync(string id);
}

public class DeviceRepository(ILogger<DeviceRepository> logger, IDeviceDBContextFactory factory)
    : IDeviceRepository
{
    private readonly ILogger<DeviceRepository> _logger = logger;
    private readonly DeviceDBContext _context = factory.CreateDbContext();

    public async Task<Device?> GetByIdAsync(string id)
    {
        return await _context.Devices.FindAsync(id);
    }

    public async Task<List<Device>> GetAllAsync()
    {
        return await _context.Devices.ToListAsync();
    }

    public async Task AddAsync(Device device)
    {
        await _context.Devices.AddAsync(device);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Device device)
    {
        _context.Devices.Update(device);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var device = await _context.Devices.FindAsync(id);

        if (device == null)
        {
            return;
        }

        _context.Devices.Remove(device);
        await _context.SaveChangesAsync();
    }
}
