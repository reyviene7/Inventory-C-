using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    public class ZReadingSummary
    {
        public string Terminal { get; set; }
        public string Cashier { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfTransactions { get; set; }
        public decimal GrossSales { get; set; }
        public decimal Discount { get; set; }
        public decimal VAT { get; set; }
        public decimal NetSales { get; set; }
        public decimal Cash { get; set; }
        public decimal GCash { get; set; }
        public decimal Credit { get; set; }
    }

}
