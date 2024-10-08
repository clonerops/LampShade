﻿using AccountManagement.Domain.AccountAgg;
using AccountManagment.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AccountManagment.Infrastructure.EfCore
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public AccountContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
