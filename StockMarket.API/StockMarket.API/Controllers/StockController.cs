using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string[] data)
        {
            createService.AddStockData(data);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
