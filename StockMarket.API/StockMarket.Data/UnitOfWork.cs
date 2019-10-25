using StockMarket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        StockMarketContext context;
        public ICompanyRepository companyRepository { get; private set; }
        public IStockPriceRepository stockPriceRepository { get; private set; }
        public UnitOfWork(string connectionString, string migrationAssemblyName)
        {
            context = new StockMarketContext(connectionString, migrationAssemblyName);
            companyRepository = new CompanyRepository(context);
            stockPriceRepository = new StockpriceRepository(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
