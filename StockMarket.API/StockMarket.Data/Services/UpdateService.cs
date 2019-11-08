using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Services
{
    public class UpdateService : IUpdateService
    {
        IUnitOfWork unitOfWork;

        public UpdateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void UpdateCompanyData(string symbol, Company company)
        {
            Company aCompany=unitOfWork.companyRepository.GetCompanyBySymbol(symbol);
            aCompany.Id = company.Id;
            aCompany.Name = company.Name;
            aCompany.Symbol = company.Symbol;
            //aCompany = company;
            unitOfWork.Save();
        }

        public void UpdateStockData(int Id, StockPrice stockPrice)
        {
            StockPrice stockData = unitOfWork.stockPriceRepository.GetStockDataById(Id);
            stockData.Id = stockPrice.Id;
            stockData.CompanyId = stockPrice.CompanyId;
            stockData.TradingDay = stockPrice.TradingDay;
            stockData.MinPrice = stockPrice.MinPrice;
            stockData.MaxPrice = stockData.MaxPrice;
            unitOfWork.Save();
        }
    }
}
