using ChampWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChampWebApp;

public class ChampoinoshipsContext:DbContext
{
    public ChampoinoshipsContext(DbContextOptions<ChampoinoshipsContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }
    
    public DbSet<Coach> Coaches { get; set; }

    public DbSet<People> Peoples { get; set; }

    public DbSet<Command> Commands { get; set; }

    public DbSet<Country> Countries { get; set; }
    
    public DbSet<GameMatch> GameMatches { get; set; }
    
    public DbSet<Tournament> Tournaments { get; set; }
    
    public DbSet<LeagueSummary> LeagueSummaries { get; set; }
    
    public DbSet<MatchEvent> MatchEvents { get; set; }
    
    public DbSet<Player> Players { get; set; }
    
    public DbSet<MatchStatistic> MatchStatistics { get; set; }
    
}