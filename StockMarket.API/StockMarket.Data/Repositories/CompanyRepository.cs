using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private StockMarketContext context;

        public CompanyRepository(StockMarketContext context)
        {
            this.context = context;
        }

        public void AddNewCompany(Company company)
        {
            context.Add(company);
        }

        public Company GetCompanyById(int Id)
        {
            return context.Companies.Where(x => x.Id == Id).Single();
        }

        public Company GetCompanyBySymbol(string symbol)
        {
            return context.Companies.Where(x => x.Symbol == symbol).Single();
        }

        public IList<string> GetAllCompanies()
        {
            var list = new List<string>();
            list=context.Companies.ToList().Select(c=>c.Name).ToList();
            return list;
        }

        public void DeleteACompany(string symbol)
        {
            Company company=GetCompanyBySymbol(symbol);
            context.Companies.Remove(company);
        }
    }
}
