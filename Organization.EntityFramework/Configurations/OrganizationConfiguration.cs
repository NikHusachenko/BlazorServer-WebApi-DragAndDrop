using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organization.Database.Entities;

namespace Organization.EntityFramework.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<OrganizationEntity>
    {
        public void Configure(EntityTypeBuilder<OrganizationEntity> builder)
        {
            builder.ToTable("Organizations").HasKey(organization => organization.Id);

            builder.HasData(new OrganizationEntity()
            {
                Id = 1,
                Name = "Organization 1",
                Index = 0,
            },
            new OrganizationEntity()
            {
                Id = 2,
                Index = 1,
                Name = "Organization 2",
            });
        }
    }
}