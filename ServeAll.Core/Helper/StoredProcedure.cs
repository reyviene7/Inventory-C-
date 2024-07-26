namespace ServeAll.Core.Helper
{
    public class StoredProcedure
    {
        public const string UspGetPasswordLogin = "usp_GetPasswordLogin";
        public const string UspTotalTemporSales = "usp_TotalTempSales";
        public const string UspInsertTempSales  = "usp_InsertTempSales";
        public const string UspSearchProducts   = "usp_get_temp_sales_counter";
        public const string UspUpdateTempSales  = "usp_update_temp_sales";
        public const string UspTenderTempSales  = "usp_tender_delete_temp_sales";
        public const string UspTenderTempCredit = "usp_TenderTempCredit";
        public const string UspTenderCredit = "usp_TenderCredit";
        public const string UspTempSales        = "usp_get_temp_sales";
        public const string UspSalesPart        = "usp_SalesParticular";
        public const string UspDelParticuSales  = "usp_DeleteParticularSales";
        public const string UspDeleteTempSales  = "usp_delete_temp_sales";
        public const string UspDeleteSales      = "usp_DeleteSales";
        public const string UspPayment          = "usp_Payment";
        public const string UspGetInventoryQty  = "usp_GetInventoryQty";
        public const string UspInsertFinger     = "usp_insert_finger";
        public const string UspReturnItemWareh  = "usp_return_item_warehouse";
        public const string UspReturnUpdWarehs  = "usp_return_edt_warehouse";
        public const string UspReturnDelWarehs  = "usp_return_del_warehouse";
        public const string UspUpdateTemInvoice = "usp_UpdateTemInvoice";
        public const string UspTempDiscount             = "usp_temp_discount";
        public const string UspSummaryParticular        = "usp_summary_particular";
        public const string UspSummaryItemBranch        = "usp_summary_item_branch";
        public const string UspDailyCreditReport        = "usp_daily_credit_report";
        public const string UspDailyCreditParticular    = "usp_daily_credit_particular";
        public const string UspPaymentTransaction       = "usp_payment_transaction";
        public const string UspBindCustomer             = "usp_bind_customer";
        public const string UspIterateBranchName = "usp_iterate_branch_name";
        public const string HassPass            = "@hassPass";
        public const string HasValue            = "@hasValue";
        public const string HasIntValue         = "@hasIntValue";
        public const string WithValue           = "@withValue";
        public const string ReturnResult        = "@retResult";
        public const string DiscountResult      = "@DiscountValue";
        public const string UspAddItemDiscount  = "usp_add_item_discount";
    }

    public class SqlVariables
    {
        public const string AmountPay   = "@AmountPay";
        public const string BarCode     = "@p_barcode";
        public const string BranchId    = "@p_branch_id";
        public const string Branch      = "@Branch";
        public const string CustomerId  = "@p_customer_id";
        public const string Customer    = "@Customer";
        public const string CreditId    = "@CreditId";
        public const string DeliveryNo  = "@DeliveryNo";
        public const string Destination = "@Destination";
        public const string Discount    = "p_discount";
        public const string EmployeeId  = "@iEmployeeId";
        public const string EndDate     = "@EndDate";
        public const string FingerIndex = "@iFingerIndex";
        public const string FingerBytes = "@iFingerBytes";
        public const string Gross       = "@Gross";
        public const string InvoicesId  = "@p_invoice_id";
        public const string InventoryId = "@InventoryId";
        public const string NetSales    = "@NetSales";
        public const string PassWord    = "@password";
        public const string PurchaseOn  = "@PurchaseOn";
        public const string ProductId   = "p_product_id";
        public const string Quantity    = "p_quantity";
        public const string Remarks     = "@Remarks";
        public const string RefDate     = "@RefDate";
        public const string ReceiptNo   = "@ReceiptNo";
        public const string ReturnId    = "@ReturnId";
        public const string ReturnCode  = "@ReturnCode";
        public const string ReturnNo    = "@ReturnNo";
        public const string ReturnQty   = "@ReturnQty";
        public const string ReturnDel   = "@ReturnDelivery";
        public const string StatusId    = "@StatusId";
        public const string StarDate    = "@StarDate";
        public const string ServiceNum  = "@ServiceNumber";
        public const string Tax         = "@Tax";
        public const string UserName    = "@p_username";
        public const string UserType    = "@p_role_id";
        public const string UserPassword = "@p_password";
        public const string UserId      = "@p_user_id";
        public const string UnitPrice   = "@UnitPrice";
        public const string SalesId     = "p_sales_id";
        public const string ProductStatusId = "p_status_id";
        public const string EmptyParam = "";
        
    }
}