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
            var url = "https://localhost:44368/api/Company/"+symbol;
            var request = WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentType = "application/json";
            var requestContent = JsonConvert.SerializeObject(company);
            var data = Encoding.UTF8.GetBytes(requestContent);
            request.ContentLength = data.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
                requestStream.Flush();
                using (var response = request.GetResponse())
                {
                    using (var streamItem = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(streamItem))
                        {
                            var result = reader.ReadToEnd();
                            //Console.WriteLine(result);
                            dynamic amount = JsonConvert.DeserializeObject(result);
                            Console.WriteLine("Amount:" + amount);
                        }
                    }
                }
            }
        }
    }
}
