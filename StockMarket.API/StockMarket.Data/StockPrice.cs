using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockMarket.Data
{
    public class StockPrice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public DateTime? TradingDay { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public Company Company { get; internal set; }
    }
}
