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
    }
}
