using Api.Services.DeviceService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.DeviceService.Infrastructure.DbContexts;

public class DeviceDBContext : DbContext
{
    public DeviceDBContext(DbContextOptions<DeviceDBContext> options)
        : base(options) { }

    public DbSet<Device> Devices { get; set; }
}
