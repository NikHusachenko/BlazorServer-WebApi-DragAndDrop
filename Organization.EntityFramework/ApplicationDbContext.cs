using Microsoft.EntityFrameworkCore;
using Organization.Database.Entities;
using Organization.EntityFramework.Configurations;

namespace Organization.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BusinessUnitEntity> BusinessUnits { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusinessUnitConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
        }
    }
}