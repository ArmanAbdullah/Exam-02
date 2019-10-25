using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Services
{
    public interface IUpdateService
    {
        void UpdateCompanyData(string symbol, Company company);
    }
}
