using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Persistence.EntityConfiguration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.ToTable("Companies");

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Employees).WithOne(x => x.Company);
        }
    }
}