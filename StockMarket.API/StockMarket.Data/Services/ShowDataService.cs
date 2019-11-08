using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Services
{
    public class ShowDataService : IShowDataService
    {
        IUnitOfWork unitOfWork;

        public ShowDataService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IList<dynamic> InnerJoinGetAllStockDataOfACompanyUsingSymbol(string symbol)
        {
            IList<dynamic> stockDataList;
            stockDataList = unitOfWork.stockPriceRepository.GetStockDataOfACompanyBySymbol(symbol);
            return stockDataList;
        }

        public IList<dynamic> InnerJoinGetAllStockDataOfACompanyUsingSymbolInADateRange(string symbol, DateTime start, DateTime end)
        {
            IList<dynamic> stockDataList;
            stockDataList = unitOfWork.stockPriceRepository.GetStockDataOfACompanyBySymbolInADateRange(symbol,start,end);
            return stockDataList;
        }

        public IList<string> ShowAllCompanies()
        {
            return unitOfWork.companyRepository.GetAllCompanies();
        }

        public string ShowCompanyNameOfGivenSymbol(string symbol)
        {
            return unitOfWork.companyRepository.GetCompanyBySymbol(symbol).Name;
        }
    }
}
