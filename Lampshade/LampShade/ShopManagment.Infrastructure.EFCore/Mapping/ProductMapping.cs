using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(255);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Keywords).HasMaxLength(80).IsRequired();
            builder.Property(x => x.MetaData).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(150).IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

        }

    }
}
