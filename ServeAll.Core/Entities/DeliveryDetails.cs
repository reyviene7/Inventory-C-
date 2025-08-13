using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeAll.Core.Entities
{
    public class DeliveryDetails
    {
        // From WarehouseDelivery
        public int delivery_id { get; set; }
        public int product_id { get; set; }
        public string delivery_code { get; set; }
        public decimal last_cost_per_unit { get; set; }
        public string receipt_number { get; set; }
        public int branch_id { get; set; }
        public int delivery_qty { get; set; }
        public int status_id { get; set; }
        public int delivery_status_id { get; set; }

        // From ViewWarehouseDelivery
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string branch_details { get; set; }
        public string status_details { get; set; }
        public decimal cost_per_unit { get; set; }
        public string delivery_status { get; set; }
    }

}
