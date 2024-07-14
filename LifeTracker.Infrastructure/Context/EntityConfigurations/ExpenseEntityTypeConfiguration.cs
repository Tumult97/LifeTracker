using LifeTracker.Domain.Models.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeTracker.Infrastructure.Context.EntityConfigurations;

public class ExpenseEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<ExpenseEntity> builder)
    {
        builder.ToTable("Expenses");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Amount)
            .HasColumnType("money")
            .IsRequired();

        builder.Property(e => e.Date)
            .IsRequired();

        builder.Property(e => e.Category)
            .IsRequired();

        builder.Property(e => e.Store)
            .IsRequired()
            .HasMaxLength(100);
    }
}