using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockMarket.Data;
using StockMarket.Data.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.API.Controllers
{
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        ICreateService createService;
        IUpdateService updateService;
        IDeleteService deleteService;
        IShowDataService showDataService;
        public StockController(ICreateService createService, IUpdateService updateService,
            IDeleteService deleteService, IShowDataService showDataService)
        {
            this.createService = createService;
            this.updateService = updateService;
            this.deleteService = deleteService;
            this.showDataService = showDataService;
        }

        // GET: api/<controller>
        [HttpGet("{ADODotNet}/{GetDataUsingAdapter}")]
        public ActionResult<DataTable> Get([FromBody] string[] Informations)
        {
            int PageIndex = Convert.ToInt32(Informations[0]);
            int PageSize= Convert.ToInt32(Informations[1]);
            string SortCol = Informations[2];
            string SortDir = Informations[3];
            string Search = Informations[4];
            DataTable dataTable = ADODotNetClass.GetDataUsingAdapter(PageIndex, PageSize, SortCol, SortDir, Search);
            return Ok(JsonConvert.SerializeObject(dataTable, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        //GET: api/<controller>/5
        [HttpGet("{symbol}")]
        public ActionResult<List<dynamic>> Get(string symbol)
        {
            var s = showDataService.InnerJoinGetAllStockDataOfACompanyUsingSymbol(symbol).ToList();
            return Ok(JsonConvert.SerializeObject(s, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        //GET: api/<controller>/5
        [HttpGet("{symbol}/{start}/{end}")]
        public ActionResult<List<dynamic>> Get(string symbol,DateTime start,DateTime end)
        {
            var s = showDataService.InnerJoinGetAllStockDataOfACompanyUsingSymbolInADateRange(symbol, start, end).ToList();
            return Ok(JsonConvert.SerializeObject(s, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string[] data)
        {
            createService.AddStockData(data);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]StockPrice stockPrice)
        {
            updateService.UpdateStockData(id, stockPrice);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{symbol}")]
        public void Delete(string symbol)
        {
            deleteService.DeleteStockData(symbol);
        }

        [HttpDelete("{symbol}/{date}")]
        public void Delete(string symbol,DateTime date)
        {
            deleteService.DeleteStockDataOfADay(symbol,date);
        }
    }
}
