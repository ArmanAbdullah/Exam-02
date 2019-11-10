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
    }
}
