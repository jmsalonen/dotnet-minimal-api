using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Services.UserService.Infrastructure.DbContexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UserDBContext>
{
    public UserDBContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<UserDBContext>()
            .UseSqlite("Data Source=:memory:")
            .Options;

        return new UserDBContext(options);
    }
}
