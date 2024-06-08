using LifeTracker.Domain.Constants.Infrastructure;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeTracker.Infrastructure.Context.EntityConfigurations;

public class UserGroupEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<UserGroupEntity> builder)
    {
        builder.ToTable("UserGroups", SchemaConstants.Users);
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.GroupId).IsRequired();
    }
}