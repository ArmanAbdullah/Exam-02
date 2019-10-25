using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connectionString;
        private string migrationAssemblyName;

        public UnitOfWork(string connectionString, string migrationAssemblyName)
        {
            this.connectionString = connectionString;
            this.migrationAssemblyName = migrationAssemblyName;
        }
    }
}
