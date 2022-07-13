using DoItFast.Domain.Models.PlanAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoItFast.Infrastructure.Persistence.Configurations
{
    public class PlanTypeConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable(nameof(Plan));

            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Admissions).WithOne().HasForeignKey(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.PlanType).WithMany().HasForeignKey(p => p.PlanTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
