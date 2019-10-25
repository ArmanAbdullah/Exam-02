using Newtonsoft.Json;
using StockMarket.Data;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Stockmarket.Client
{
    class Add
    {
        internal static void AddCompany()
        {
            Console.WriteLine("Enter Id:");
            var Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Symbol:");
            var symbol = Console.ReadLine();
            Company company = new Company()
            {
                Id = Id,
                Name = name,
                Symbol=symbol
            };

            const string url = "https://localhost:44368/api/Company";
            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            var requestContent = JsonConvert.SerializeObject(company);
            var data = Encoding.UTF8.GetBytes(requestContent);
            request.ContentLength = data.Length;
            using (var requsetStream = request.GetRequestStream())
            {
                requsetStream.Write(data, 0, data.Length);
                requsetStream.Flush();
                request.GetResponse();
            }
        }

        internal static void AddStockData()
        {
            var informations = new string[6];
            Console.WriteLine("Enter Id:");
            informations[0] = Console.ReadLine();
            Console.WriteLine("Enter Company id:");
            informations[1] = Console.ReadLine();
            Console.WriteLine("Enter trading date");
            informations[2] = Console.ReadLine();
            Console.WriteLine("Enter Min price:");
            informations[3] = Console.ReadLine();
            Console.WriteLine("Enter Max price:");
            informations[4] = Console.ReadLine();

            const string url = "https://localhost:44368/api/Stock";
            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            var requestContent = JsonConvert.SerializeObject(informations);
            var data = Encoding.UTF8.GetBytes(requestContent);
            request.ContentLength = data.Length;
            using (var requsetStream = request.GetRequestStream())
            {
                requsetStream.Write(data, 0, data.Length);
                requsetStream.Flush();
                request.GetResponse();
            }
        }
    }
}
