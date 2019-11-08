using Newtonsoft.Json;
using StockMarket.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Stockmarket.Client
{
    class ShowData
    {
        internal static void ShowCompanyNameOfTheSymbol()
        {
            Console.WriteLine("Enter Symbol:");
            var symbol = Console.ReadLine();
            string url = "https://localhost:44368/api/Company/" + symbol + "/";
            var request = WebRequest.Create(url);
            request.Method = "GET";
            using (var response = request.GetResponse())
            {
                using (var streamItem = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(streamItem))
                    {
                        var result = reader.ReadToEnd();
                        Console.WriteLine(result);
                        //dynamic name = JsonConvert.DeserializeObject(result);
                        //Console.WriteLine(name);
                    }
                }
            }
        }

        internal static void ShowAllCompanyNames()
        {
            string url = "https://localhost:44368/api/Company";
            var request = WebRequest.Create(url);
            request.Method = "GET";
            using (var response = request.GetResponse())
            {
                using (var streamItem = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(streamItem))
                    {
                        var result = reader.ReadToEnd();
                        dynamic list = JsonConvert.DeserializeObject(result);
                        foreach (string st in list)
                        {
                            Console.WriteLine(st);
                        }
                    }
                }
            }
        }

        internal static void ShowStockDataInADateRangeOfACompany()
        {
            Console.WriteLine("Enter Symbol:");
            var symbol = Console.ReadLine();
            Console.WriteLine("Enter start date");
            var startDate = Console.ReadLine();
            Console.WriteLine("Enter end date");
            var endDate = Console.ReadLine();
            string url = "https://localhost:44368/api/Stock/" + symbol + "/" + startDate + "/" + endDate + "/";
            Console.WriteLine(url);
            var request = WebRequest.Create(url);
            request.Method = "GET";
            using (var response = request.GetResponse())
            {
                using (var streamItem = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(streamItem))
                    {
                        var result = reader.ReadToEnd();
                        dynamic list = JsonConvert.DeserializeObject(result);
                        foreach (dynamic st in list)
                        {
                            Console.WriteLine(st);
                        }
                    }
                }
            }
        }

        internal static void ShowStockdataOfACompany()
        {
            Console.WriteLine("Enter Symbol:");
            var symbol = Console.ReadLine();
            string url = "https://localhost:44368/api/Stock/" + symbol+"/";
            var request = WebRequest.Create(url);
            request.Method = "GET";
            using (var response = request.GetResponse())
            {
                using (var streamItem = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(streamItem))
                    {
                        var result = reader.ReadToEnd();
                        dynamic list = JsonConvert.DeserializeObject(result);
                        foreach (dynamic st in list)
                        {
                            Console.WriteLine(st);
                        }
                    }
                }
            }
        }

        internal static void Search()
        {
            var informations = new string[5];
            Console.WriteLine("Enter page index.");
            informations[0] = Console.ReadLine();
            Console.WriteLine("Enter page size.");
            informations[1] = Console.ReadLine();
            Console.WriteLine("Enter column name to sort.");
            informations[2] = Console.ReadLine();
            Console.WriteLine("ASC/DESC order?");
            informations[3] = Console.ReadLine();
            Console.WriteLine("Enter text to seach.");
            informations[4] = Console.ReadLine();
            string url = "https://localhost:44368/api/Stock/ADODotNet/GetDataUsingAdapter/";
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
                using (var response = request.GetResponse())
                {
                    using (var streamItem = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(streamItem))
                        {
                            var result = reader.ReadToEnd();
                            dynamic list = JsonConvert.DeserializeObject(result);
                            foreach (dynamic st in list)
                            {
                                Console.WriteLine(st);
                            }
                        }
                    }
                }
            }
        }
    }
}
