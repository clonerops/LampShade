using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Infrastructure.EFCore.Mapping;
using System;

namespace ShopManagment.Infrastructure.EFCore
{
    public class EfContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
