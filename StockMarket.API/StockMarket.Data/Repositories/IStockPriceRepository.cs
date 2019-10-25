using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Repositories
{
    public interface IStockPriceRepository
    {
        void AddNewStockData(StockPrice stockPrice);
        StockPrice GetStockDataById(int Id);
    }
}
