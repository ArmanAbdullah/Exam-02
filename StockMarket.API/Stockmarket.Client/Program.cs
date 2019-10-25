using System;

namespace Stockmarket.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Stock Market management system.\n" +
                "Enter your choice:\n" +
                "1.Entry a new Company's Info.\n" +
                "2.Update a Company's Info.\n" +
                "3.Delete a Company's Info.\n" +
                "4.See all companies name.\n" +
                "5.See company name by symbol.\n"+
                "6.Add Stock data:");

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
            }
        }
    }
}
