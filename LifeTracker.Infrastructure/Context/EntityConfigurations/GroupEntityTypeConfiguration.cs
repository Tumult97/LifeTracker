using LifeTracker.Domain.Constants.Infrastructure;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeTracker.Infrastructure.Context.EntityConfigurations;

public class GroupEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<GroupEntity> builder)
    {
        builder.ToTable("Groups", SchemaConstants.Users);
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(2000);
        builder.Property(x => x.Address);
        builder.HasMany(x => x.Users)
               .WithMany(x => x.Groups)
               .UsingEntity<UserGroupEntity>();
    }
}