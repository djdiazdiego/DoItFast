using DoItFast.Domain.Models.PlanAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoItFast.Infrastructure.Persistence.Configurations
{
    public class AdmissionTypeConfiguration : IEntityTypeConfiguration<Admission>
    {
        public void Configure(EntityTypeBuilder<Admission> builder)
        {
            builder.ToTable(nameof(Admission));

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.PriorityType).WithMany().HasForeignKey(p => p.PriorityTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
