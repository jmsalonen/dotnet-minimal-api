using Microsoft.EntityFrameworkCore;

namespace Api.Services.DeviceService.Infrastructure.DbContexts;

public interface IDeviceDBContextFactory
{
    DeviceDBContext CreateDbContext();
}

public class DeviceDBContextFactory : IDeviceDBContextFactory
{
    private readonly IConfiguration _configuration;

    public DeviceDBContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DeviceDBContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<DeviceDBContext>();
        optionsBuilder.UseSqlite(_configuration["ConnectionStrings:DefaultConnection"]);

        return new DeviceDBContext(optionsBuilder.Options);
    }
}
