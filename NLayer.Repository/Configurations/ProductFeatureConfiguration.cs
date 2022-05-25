using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations
{
    internal class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(pf => pf.Id);
            builder.Property(pf => pf.Id).UseIdentityColumn();

            builder.HasOne(pf => pf.Product)
                .WithOne(p => p.ProductFeature)
                .HasForeignKey<ProductFeature>(pf => pf.ProductId);
        }
    }
}
