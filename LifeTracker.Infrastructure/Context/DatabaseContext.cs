using LifeTracker.Domain.Models.Infrastructure;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Infrastructure.Context;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<UserEntity> users { get; init; } = null!;
    public DbSet<GroupEntity> groups { get; init; } = null!;
    public DbSet<UserGroupEntity> userGroups { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<UserEntity>());
        new GroupEntityTypeConfiguration().Configure(modelBuilder.Entity<GroupEntity>());
        new UserGroupEntityTypeConfiguration().Configure(modelBuilder.Entity<UserGroupEntity>());
    }
}