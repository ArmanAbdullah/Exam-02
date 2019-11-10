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

        public StockPrice GetStockDataById(int Id)
        {
            return context.StockPrices.Where(x => x.Id == Id).Single();
        }
    }
}
