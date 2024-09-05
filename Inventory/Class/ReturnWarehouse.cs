 

using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Class
{
    public class ReturnWarehouse
    {
        public int Id               { get; set; }
        public string   Item        { get; set; }
        public int Qty { get; set; }
        public string   Delivery    { get; set; }
        public string Origin        { get; set; }
        public decimal RetailPrice  { get; set; }
        public DateTime RetDate     { get; set; }
        public string Status        { get; set; }
        public string Remarks       { get; set; }
    }
}
