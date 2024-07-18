using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.ProductPictureAgg;

namespace ShopManagment.Infrastructure.EFCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PictureTitle);
            builder.Property(x => x.PictureAlt);
            builder.Property(x => x.PictureUrl);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductPictures)
                .HasForeignKey(x => x.ProductId);

        }

    }
}
