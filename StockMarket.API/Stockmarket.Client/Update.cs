using Newtonsoft.Json;
using StockMarket.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Stockmarket.Client
{
    class Update
    {
        internal static void UpdateCompanyData()
        {
            Console.WriteLine("Enter Symbol:");
            var symbol = Console.ReadLine();
            Console.WriteLine("Enter new Id:");
            var Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter new Symbol:");
            var newsymbol = Console.ReadLine();
            Company company = new Company()
            {
                Id = Id,
                Name = name,
                Symbol = newsymbol
            };
            var url = "https://localhost:44368/api/Company/"+symbol + "/";
            UpdateData(url, company);
        }

        internal static void UpdateStockData()
        {
            Console.WriteLine("Enter id:");
            var oldId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Id:");
            var Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Company id:");
            var companyId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new min price:");
            var minPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter new max price:");
            var maxPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter new date:");
            var tradingDate = Convert.ToDateTime(Console.ReadLine());
            StockPrice stockPrice = new StockPrice()
            {
                Id = Id,
                CompanyId = companyId,
                MinPrice = minPrice,
                MaxPrice=maxPrice,
                TradingDay=tradingDate
            };
            var url = "https://localhost:44368/api/Stock/" + oldId + "/";
            UpdateData(url, stockPrice);
        }

        private static void UpdateData(string url,dynamic anObject)
        {
            var request = WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentType = "application/json";
            var requestContent = JsonConvert.SerializeObject(anObject);
            var data = Encoding.UTF8.GetBytes(requestContent);
            request.ContentLength = data.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
                requestStream.Flush();
                request.GetResponse();
            }
        }
    }
}
