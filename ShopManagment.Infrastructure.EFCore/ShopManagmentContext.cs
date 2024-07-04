using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Infrastructure.EFCore.Mapping;

namespace ShopManagment.Infrastructure.EFCore
{
    public class ShopManagmentContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public ShopManagmentContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
