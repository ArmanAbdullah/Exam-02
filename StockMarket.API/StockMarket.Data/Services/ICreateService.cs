using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Services
{
    public interface ICreateService
    {
        void AddNewCompanyData(Company company);
        void AddStockData(string[] data);
    }
}
