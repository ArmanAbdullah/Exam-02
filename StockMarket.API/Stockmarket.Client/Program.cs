using StockMarket.Data;
using System;
using System.Data;

namespace Stockmarket.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataTable dataTable = ADODotNetClass.GetDataUsingAdapter(1, 1, "Symbol", "ASC", "GP");
            Console.WriteLine("Welcome to Stock Market management system.\n" +
                "Enter your choice:\n" +
                "1.Entry a new Company's Info.\n" +
                "2.Update a Company's Info.\n" +
                "3.Delete a Company's Info.\n" +
                "4.See all companies name.\n" +
                "5.See company name by symbol.\n"+
                "6.Add Stock data.\n"+
                "7.See all Stock Data of a Company.\n"+
                "8.See the stock records within the date range for a company.\n"+
                "9.Updates stock information.\n" +
                "10.Delete all stock data information for a company.\n"+
                "11.Delete all stock data information for a company of a day.\n" +
                "12.Search(ADO.Net-Store Procedure).\n");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Add.AddCompany();
                    break;
                case 2:
                    Update.UpdateCompanyData();
                    break;
                case 3:
                    Delete.DeleteCompanyData();
                    break;
                case 4:
                    ShowData.ShowAllCompanyNames();
                    break;
                case 5:
                    ShowData.ShowCompanyNameOfTheSymbol();
                    break;
                case 6:
                    Add.AddStockData();
                    break;
                case 7:
                    ShowData.ShowStockdataOfACompany();
                    break;
                case 8:
                    ShowData.ShowStockDataInADateRangeOfACompany();
                    break;
                case 9:
                    Update.UpdateStockData();
                    break;
                case 10:
                    Delete.DeleteAllStockDataOfACompany();
                    break;
                case 11:
                    Delete.DeleteAllStockDataOfACompanyInADay();
                    break;
                case 12:
                    ShowData.Search();
                    break;
            }
        }
    }
}
