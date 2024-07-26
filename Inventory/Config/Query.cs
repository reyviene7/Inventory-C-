namespace Inventory.Config
{
    public class Query
    {
        public const string SelectAllDepot = "SELECT Id, Code, Item, Qty, DeliveryNo, ReceiptNo, Branch, LastCost, OnOrder, Purchase, RefDate, Warranty, Status FROM view_depot ORDER BY Id DESC";
        public const string SelectAllDeliv = "SELECT TOP 1 DeliveryNo FROM view_depot ORDER BY Id DESC";
    }
}