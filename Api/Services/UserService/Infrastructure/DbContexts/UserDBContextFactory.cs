using Microsoft.EntityFrameworkCore;

namespace Api.Services.UserService.Infrastructure.DbContexts;

public interface IUserDBContextFactory
{
    UserDBContext CreateDbContext();
}

public class UserDBContextFactory : IUserDBContextFactory
{
    private readonly IConfiguration _configuration;

    public UserDBContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public UserDBContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<UserDBContext>();
        optionsBuilder.UseSqlite(_configuration["ConnectionStrings:DefaultConnection"]);

        return new UserDBContext(optionsBuilder.Options);
    }
}
