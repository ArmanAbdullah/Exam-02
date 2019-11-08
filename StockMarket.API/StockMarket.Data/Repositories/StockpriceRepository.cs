using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket.Data.Repositories
{
    public class StockpriceRepository : IStockPriceRepository
    {
        private StockMarketContext context;

        public StockpriceRepository(StockMarketContext context)
        {
            this.context = context;
        }

        public void AddNewStockData(StockPrice stockPrice)
        {
            context.Add(stockPrice);
        }

        public void DeleteAllStockDataOfACompany(int CompanyId)
        {
            context.StockPrices.RemoveRange(context.StockPrices.Where(sd=>sd.CompanyId==CompanyId));
        }

        public void DeleteStockDataOfAComanyInADay(int companyId, DateTime date)
        {
            context.StockPrices.RemoveRange(context.StockPrices.Where(sd => sd.CompanyId == companyId && sd.TradingDay==date));
        }

        public StockPrice GetStockDataById(int Id)
        {
            StockPrice stockData = context.StockPrices.Where(sd => sd.Id == Id).Single();
            return stockData;
        }

        public IList<dynamic> GetStockDataOfACompanyBySymbol(string symbol)
        {
            var listOfStockData = context.Companies.Include(c=>c.StockPrices).
                Where(c => c.Symbol == symbol).ToList();
            return listOfStockData.ToList<dynamic>();
        }

        public IList<dynamic> GetStockDataOfACompanyBySymbolInADateRange(string symbol, DateTime start, DateTime end)
        {
            var listOfStockData = (from c in context.Companies join sd in context.StockPrices on c.Id equals
                                   sd.CompanyId where c.Symbol==symbol && sd.TradingDay>=start && sd.TradingDay<=end 
                                   select new
                                   {
                                       sd.Id,
                                       c.Name,
                                       sd.TradingDay,
                                       sd.MinPrice,
                                       sd.MaxPrice
                                   }).ToList();
            return listOfStockData.ToList<dynamic>();
        }
    }
}
