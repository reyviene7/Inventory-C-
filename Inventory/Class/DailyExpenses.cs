 

using System;

namespace Inventory.Class
{
   public class DailyExpenses
   {
        public int Id      { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Employee { get; set; }

        public string RelatedEntity { get; set; }
        public int EntityId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
