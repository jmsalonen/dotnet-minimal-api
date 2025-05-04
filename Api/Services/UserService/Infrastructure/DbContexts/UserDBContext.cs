using Api.Services.UserService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.UserService.Infrastructure.DbContexts;

public class UserDBContext : DbContext
{
    public UserDBContext(DbContextOptions<UserDBContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
}
