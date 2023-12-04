using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organization.Database.Entities;

namespace Organization.EntityFramework.Configurations
{
    public class BusinessUnitConfiguration : IEntityTypeConfiguration<BusinessUnitEntity>
    {
        public void Configure(EntityTypeBuilder<BusinessUnitEntity> builder)
        {
            builder.ToTable("Business units").HasKey(unit => unit.Id);

            builder.HasOne<CompanyEntity>(unit => unit.Company)
                .WithMany(company => company.BusinessUnits)
                .HasForeignKey(unit => unit.CompanyFk)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
            // For Company 'Child 1' in Organization 1
            new BusinessUnitEntity()
            {
                Id = 1,
                Index = 0,
                Name = "1",
                CompanyFk = 1,
            },
            new BusinessUnitEntity()
            {
                Id = 2,
                Index = 1,
                Name = "2",
                CompanyFk = 1,
            },
            new BusinessUnitEntity()
            {
                Id = 3,
                Index = 2,
                Name = "3",
                CompanyFk = 1,
            },
            new BusinessUnitEntity()
            {
                Id = 4,
                Index = 3,
                Name = "4",
                CompanyFk = 1,
            },
            new BusinessUnitEntity()
            {
                Id = 5,
                Index = 4,
                Name = "5",
                CompanyFk = 1,
            },

            // For Company 'Child 2' in Organization 1
            new BusinessUnitEntity()
            {
                Id = 6,
                Index = 0,
                Name = "1",
                CompanyFk = 2,
            },
            new BusinessUnitEntity()
            {
                Id = 7,
                Index = 1,
                Name = "2",
                CompanyFk = 2,
            },
            new BusinessUnitEntity()
            {
                Id = 8,
                Index = 2,
                Name = "3",
                CompanyFk = 2,
            },
            new BusinessUnitEntity()
            {
                Id = 9,
                Index = 3,
                Name = "4",
                CompanyFk = 2,
            },
            new BusinessUnitEntity()
            {
                Id = 10,
                Index = 4,
                Name = "5",
                CompanyFk = 2,
            },

            // For Company 'Child 3' in Organization 1
            new BusinessUnitEntity()
            {
                Id = 11,
                Index = 0,
                Name = "1",
                CompanyFk = 3,
            },
            new BusinessUnitEntity()
            {
                Id = 12,
                Index = 1,
                Name = "2",
                CompanyFk = 3,
            },
            new BusinessUnitEntity()
            {
                Id = 13,
                Index = 2,
                Name = "3",
                CompanyFk = 3,
            },
            new BusinessUnitEntity()
            {
                Id = 14,
                Index = 3,
                Name = "4",
                CompanyFk = 3,
            },
            new BusinessUnitEntity()
            {
                Id = 15,
                Index = 4,
                Name = "5",
                CompanyFk = 3,
            },
            new BusinessUnitEntity()
            {
                Id = 16,
                Index = 5,
                Name = "6",
                CompanyFk = 3,
            },
            new BusinessUnitEntity()
            {
                Id = 17,
                Index = 6,
                Name = "7",
                CompanyFk = 3,
            },

            // For Company 'Child 1' in Organization 2;
            new BusinessUnitEntity()
            {
                Id = 18,
                Index = 0,
                Name = "1",
                CompanyFk = 4,
            },
            new BusinessUnitEntity()
            {
                Id = 19,
                Index = 1,
                Name = "2",
                CompanyFk = 4,
            },
            new BusinessUnitEntity()
            {
                Id = 20,
                Index = 2,
                Name = "3",
                CompanyFk = 4,
            },
            new BusinessUnitEntity()
            {
                Id = 21,
                Index = 3,
                Name = "4",
                CompanyFk = 4,
            },
            new BusinessUnitEntity()
            {
                Id = 22,
                Index = 4,
                Name = "5",
                CompanyFk = 4,
            },
            new BusinessUnitEntity()
            {
                Id = 23,
                Index = 5,
                Name = "6",
                CompanyFk = 4,
            },
            new BusinessUnitEntity()
            {
                Id = 24,
                Index = 6,
                Name = "7",
                CompanyFk = 4,
            });
        }
    }
}