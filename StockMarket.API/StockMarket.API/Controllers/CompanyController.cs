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
    public class CompanyController : Controller
    {
        ICreateService createService;
        IUpdateService updateService;
        IDeleteService deleteService;
        IShowDataService showDataService;
        public CompanyController(ICreateService createService,IUpdateService updateService,
            IDeleteService deleteService,IShowDataService showDataService)
        {
            this.createService = createService;
            this.updateService = updateService;
            this.deleteService = deleteService;
            this.showDataService = showDataService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<string> Get()
        {
            var listOfCompanies = showDataService.ShowAllCompanies();
            return listOfCompanies;
        }

        // GET api/<controller>/5
        [HttpGet("{symbol}")]
        public string Get(string symbol)
        {
            var companyName = showDataService.ShowCompanyNameOfGivenSymbol(symbol);
            return companyName;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Company company)
        {
            createService.AddNewCompanyData(company);
        }

        // PUT api/<controller>/5
        [HttpPut("{symbol}")]
        public void Put(string symbol, [FromBody]Company company)
        {
            updateService.UpdateCompanyData(symbol,company);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{symbol}")]
        public void Delete(string symbol)
        {
            deleteService.DeleteACompany(symbol);
        }
    }
}
