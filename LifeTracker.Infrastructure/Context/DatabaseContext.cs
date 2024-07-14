using LifeTracker.Domain.Models.Infrastructure;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Infrastructure.Context;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<ExpenseEntity> Expenses { get; init; } = null!;
    public DbSet<UserEntity> Users { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ExpenseEntityTypeConfiguration().Configure(modelBuilder.Entity<ExpenseEntity>());
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<UserEntity>());
    }
}