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
        }
    }
}
