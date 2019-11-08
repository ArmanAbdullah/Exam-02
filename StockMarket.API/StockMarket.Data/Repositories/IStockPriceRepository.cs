using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Repositories
{
    public interface IStockPriceRepository
    {
        void AddNewStockData(StockPrice stockPrice);
        StockPrice GetStockDataById(int Id);
        IList<dynamic> GetStockDataOfACompanyBySymbol(string symbol);
        IList<dynamic> GetStockDataOfACompanyBySymbolInADateRange(string symbol, DateTime start, DateTime end);
        void DeleteAllStockDataOfACompany(int CompanyId);
        void DeleteStockDataOfAComanyInADay(int companyId, DateTime date);
    }
}
