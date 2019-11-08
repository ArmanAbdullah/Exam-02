using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Services
{
    public interface IDeleteService
    {
        void DeleteACompany(string symbol);
        void DeleteStockData(string symbol);
        void DeleteStockDataOfADay(string symbol,DateTime date);
    }
}
