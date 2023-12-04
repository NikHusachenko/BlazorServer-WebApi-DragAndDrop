using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organization.Database.Entities;

namespace Organization.EntityFramework.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.ToTable("Companies").HasKey(company => company.Id);

            builder.HasOne<OrganizationEntity>(company => company.Organization)
                .WithMany(organization => organization.Companies)
                .HasForeignKey(company => company.OrganizationFk)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
            // For Organization 1
            new CompanyEntity()
            {
                Id = 1,
                Index = 0,
                Name = "Child 1",
                OrganizationFk = 1,
            },
            new CompanyEntity() 
            {
                Id = 2,
                Index = 1,
                Name = "Child 2",
                OrganizationFk = 1,
            },
            new CompanyEntity()
            {
                Id = 3,
                Index = 2,
                Name = "Child 3",
                OrganizationFk = 1,
            },
            
            // For Organization 2
            new CompanyEntity()
            {
                Id = 4,
                Index = 0,
                Name = "Child 1",
                OrganizationFk = 2,
            });
        }
    }
}