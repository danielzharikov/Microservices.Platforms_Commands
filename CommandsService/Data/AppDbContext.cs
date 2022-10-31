using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Command> Commands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Platform>()
            .HasMany(platform => platform.Commands)
            .WithOne(platform => platform.Platform!)
            .HasForeignKey(platform => platform.PlatformId);

        modelBuilder
            .Entity<Command>()
            .HasOne(command => command.Platform)
            .WithMany(command => command.Commands)
            .HasForeignKey(command => command.PlatformId);
    }
}