using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Application;
using ShopManagment.Application.Contract.Product;
using ShopManagment.Application.Contract.ProductCategory;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Infrastructure.EFCore;
using ShopManagment.Infrastructure.EFCore.Repository;

namespace ShopManagment.Configuration
{
    public class ShopManagmentBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddDbContext<EfContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
