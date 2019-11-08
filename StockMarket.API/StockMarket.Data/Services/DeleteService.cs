using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Services
{
    public class DeleteService : IDeleteService
    {
        IUnitOfWork unitOfWork;

        public DeleteService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void DeleteACompany(string symbol)
        {
            unitOfWork.companyRepository.DeleteACompany(symbol);
            unitOfWork.Save();
        }

        public void DeleteStockData(string symbol)
        {
            int companyId = unitOfWork.companyRepository.GetCompanyBySymbol(symbol).Id;
            unitOfWork.stockPriceRepository.DeleteAllStockDataOfACompany(companyId);
            unitOfWork.Save();
        }

        public void DeleteStockDataOfADay(string symbol, DateTime date)
        {
            int companyId = unitOfWork.companyRepository.GetCompanyBySymbol(symbol).Id;
            unitOfWork.stockPriceRepository.DeleteStockDataOfAComanyInADay(companyId, date);
            unitOfWork.Save();
        }
    }
}
