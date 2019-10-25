using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data
{
    public class StockMarketContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public StockMarketContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(optionBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Company>()
                .HasMany(c => c.StockPrices)
                .WithOne(c=>c.Company)
                .HasForeignKey(ib => ib.CompanyId);
            base.OnModelCreating(builder);
        }

        public StockMarketContext(DbContextOptions options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
    }
}
