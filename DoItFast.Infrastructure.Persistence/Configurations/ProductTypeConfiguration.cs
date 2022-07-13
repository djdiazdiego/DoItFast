using DoItFast.Domain.Models;
using DoItFast.Infrastructure.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoItFast.Infrastructure.Persistence.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100);

            builder.Property(p => p.Properties)
                .HasConversion(ConverterExtensions.ConverterAnyObject<List<KeyValuePair<string, string>>>());
        }
    }
}
