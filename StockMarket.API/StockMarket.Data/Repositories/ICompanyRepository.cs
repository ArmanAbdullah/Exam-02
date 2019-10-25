using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data.Repositories
{
    public interface ICompanyRepository
    {
        void AddNewCompany(Company company);
        Company GetCompanyById(int Id);
        Company GetCompanyBySymbol(string symbol);
        IList<string> GetAllCompanies();
        void DeleteACompany(string symbol);
    }
}
