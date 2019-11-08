using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Services
{
    public interface IShowDataService
    {
        IList<string> ShowAllCompanies();
        string ShowCompanyNameOfGivenSymbol(string symbol);
        IList<dynamic> InnerJoinGetAllStockDataOfACompanyUsingSymbol(string symbol);
        IList<dynamic> InnerJoinGetAllStockDataOfACompanyUsingSymbolInADateRange(string symbol, DateTime start, DateTime end);
    }
}
