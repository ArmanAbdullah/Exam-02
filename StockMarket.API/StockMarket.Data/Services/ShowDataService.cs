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
