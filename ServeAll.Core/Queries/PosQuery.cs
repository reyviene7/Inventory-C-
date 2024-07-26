namespace ServeAll.Core.Queries
{
    public static class PosQuery
    {
        public const string Selectall = "SELECT CategoryId, CategoryCode, CategoryDetails, ImageId, DateRegister FROM Category";
        public const string InsertCategory = @"INSERT INTO Category(CategoryCode, CategoryDetails, ImageId, DateRegister) VALUES(@CategoryCode, @CategoryDetails, @ImageId, @DateRegister)";
        public const string SalesCredit = "SELECT Id, Invoice, ServiceNo, Customer, AmountCredit, PaidAmount, Branch, RefDate FROM view_salescredit ORDER BY Id DESC";
        public const string AllCreditPayment = "SELECT Id, Invoice, ServiceNo, PayAmount, Customer, Branch, RefDate FROM view_payment ORDER BY Id DESC";
        public const string AllCreditParticular = "SELECT Id, Invoice, Customer,ItemName, Code, Qty, UnitPrice, Discount, Gross, NetSales,Branch, RefDate FROM view_credit_particular ORDER BY Id DESC";
    }
}