using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Stockmarket.Client
{
    class Delete
    {
        internal static void DeleteCompanyData()
        {
            Console.WriteLine("Enter Symbol:");
            var symbol = Console.ReadLine();
            string url = "https://localhost:44368/api/Company/"+symbol + "/";
            DeleteData(url);
        }

        internal static void DeleteAllStockDataOfACompany()
        {
            Console.WriteLine("Enter Symbol:");
            var symbol = Console.ReadLine();
            string url = "https://localhost:44368/api/Stock/" + symbol + "/";
            DeleteData(url);
        }
    
        internal static void DeleteAllStockDataOfACompanyInADay()
        {
            Console.WriteLine("Enter Symbol:");
            var symbol = Console.ReadLine();
            Console.WriteLine("Enter Date:");
            var date = Console.ReadLine();
            string url = "https://localhost:44368/api/Stock/" + symbol+"/"+ date + "/";
            DeleteData(url);
        }

        private static void DeleteData(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = "DELETE";
            using (var requsetStream = request.GetRequestStream())
            {
                request.GetResponse();
            }
        }
    }
}
