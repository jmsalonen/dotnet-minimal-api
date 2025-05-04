using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Services.DeviceService.Infrastructure.DbContexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DeviceDBContext>
{
    public DeviceDBContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<DeviceDBContext>()
            .UseSqlite("Data Source=:memory:")
            .Options;

        return new DeviceDBContext(options);
    }
}
