using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Application;
using ShopManagment.Application.contracts.ProductCategory.contract;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Infrastructure.EFCore;
using ShopManagment.Infrastructure.EFCore.Repository;

namespace ShopManagment.Infrastructure.Configuration
{
    public class ShopManagmentBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddDbContext<ShopManagmentContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
