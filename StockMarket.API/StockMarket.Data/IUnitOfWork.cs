using StockMarket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data
{
    public interface IUnitOfWork
    {
        ICompanyRepository companyRepository { get; }
        IStockPriceRepository stockPriceRepository { get; }
        void Save();
    }
}
