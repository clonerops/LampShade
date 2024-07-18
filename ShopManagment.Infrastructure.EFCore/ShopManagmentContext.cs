using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Domain.ProductPictureAgg;
using ShopManagment.Infrastructure.EFCore.Mapping;

namespace ShopManagment.Infrastructure.EFCore
{
    public class ShopManagmentContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public ShopManagmentContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductPictureMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
