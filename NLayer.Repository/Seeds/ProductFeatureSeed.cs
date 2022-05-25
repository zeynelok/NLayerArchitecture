using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature { Id = 1, ProductId = 1, Height = 100, Width = 20, Color = "Kırmızı" },
                new ProductFeature { Id = 2, ProductId = 2, Height = 500, Width = 200, Color = "Siyah" });
        }
    }
}
