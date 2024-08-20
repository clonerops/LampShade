using _0_Framework.Application;
using AccountManagement.Domain.AccountAgg;
using AccountManagment.Application;
using AccountManagment.Application.contracts;
using AccountManagment.Infrastructure.EfCore;
using AccountManagment.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagment.Infrastructure.Configuration
{
    public class AccountManagmentBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {

            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}