using LifeTracker.Domain.Constants.Infrastructure;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeTracker.Infrastructure.Context.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users", SchemaConstants.Users);
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(200);
        builder.Property(x => x.PasswordSalt).IsRequired().HasMaxLength(2000);
        builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(2000);
        builder.HasMany(x => x.Groups).WithMany(x => x.Users);
    }
}