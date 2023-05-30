using ChampWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChampWebApp;

public class ChampoinoshipsContext:DbContext
{
    public ChampoinoshipsContext(DbContextOptions<ChampoinoshipsContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    
    public DbSet<Role> Roles { get; set; }
}