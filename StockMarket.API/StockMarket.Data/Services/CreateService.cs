using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Services
{
    public class CreateService : ICreateService
    {
        IUnitOfWork unitOfWork;

        public CreateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddNewCompanyData(Company company)
        {
            unitOfWork.companyRepository.AddNewCompany(company);
            unitOfWork.Save();
        }

        public void AddStockData(string[] data)
        {
            var stockPrice = new StockPrice()
            {
                Id = Convert.ToInt32(data[0]),
                CompanyId = Convert.ToInt32(data[1]),
                TradingDay = Convert.ToDateTime (data[2]),
                MinPrice=Convert.ToDouble(data[3]),
                MaxPrice=Convert.ToDouble(data[4])
            };

            unitOfWork.stockPriceRepository.AddNewStockData(stockPrice);
            unitOfWork.Save();
        }
    }
}
