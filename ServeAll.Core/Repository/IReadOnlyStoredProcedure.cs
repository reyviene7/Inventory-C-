using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace ServeAll.Core.Repository
{
    public interface IReadOnlyStoredProcedure<T> where T: class 
    {
        int ExeStoredProcLogin(string procedureName, string input1, string val1, string input2, string val2, string typ, int valtyp);
        SqlByte ExecStoredProc(string procName, string inpt, string val);
        string ExecLoginUser(string procName, string userName, string userValue, string userType, int typValue);
        decimal ExecPosTotalTemp(string procName, string inpCustomer, int customerId, string inpInvoice, string invoice, string inpBranch, int branchId);
        int ExecCancelTemp(string procName, string inpInvoice, string valInvoice, string inpBarcode, string valBarcode, string inpBranch, int branchId, string inpCustomer, int customerId);
       // int ExecUpdateTemp(string procName, string inpInvoice, string valInvoice, string inpBarcode, string valBarcode, string inpBranch, int branchId, string inpCustomer, int customerId, string inpQuantity, decimal quantity);
        int ExecUpdateTemp(
            string procName,
            string invoice,
            string invoiceValue,
            string barcode,
            string barcodeValue,
            string branch,
            int branchIdValue,
            string customerId,
            int customerIdValue,
            string productId,
            int productIdValue,
            string inpQuantity,
            decimal quantity
            );
        int ExecInsertTemp(string procName,   string inpInvoiceId, string vInvoiceId,
                                              string inpProductId, int vProductId,
                                              string inpBarcode,   string vBarcode,
                                              string inpQuantity,  int vQuantity,
                                              string inpUnitPrice, decimal vUnitPrice,
                                              string inpTax,       decimal vTax,
                                              string inpDiscount,  decimal vDiscount,
                                              string inpGross,     decimal vGross,
                                              string inpNetSales,  decimal vNetSales,
                                              string inpCustomerId,int vCustomerId,
                                              string inpUserId,    int vUserId,
                                              string inpBranchId,  int vBranchId,
                                              string inpPurchaseOn, DateTime vPurchaseOn);
        IEnumerable<T> ExecSelectAll(string procName, string inpBranch, int branchId, string inpCustomer, int customerId);

        int ExecGetInventoryQty(string procedureName,
            string inpProcId, int productId,
            string inpBranId, int branchId,
            string inpDeleNo, string deliveryNo,
            string inpReceNo, string receiptNo);

        int ExecuteFinger(string procedureName, 
                         string inEmployeeId,  int employeeId,
                         string inFingerIndex, int fingerIndex, 
                         string inFingerBytes, string fingerBytes);

        int ExecuteReturnWarehouse(string procName,
            string inReturnId, int returnId,
            string inReturnCd, string returnCd,
            string inProdctId, int productId,
            string inReturnNo, string returnNo,
            string inReturnQt, decimal returnQty,
            string inBranchId, int branchId,
            string inDestines, int destination,
            string inRetrnDet, DateTime returnDate,
            string inRefeDate, DateTime referDate,
            string inStatusId, int statusId,
            string inRermarks, string remarks, 
            string inInventId, int inventoryId);

        int ExecuteRetUpdWarehouse(string procName,
            string inReturnId, int returnId,
            string inReturnCd, string returnCd,
            string inProdctId, int productId,
            string inReturnNo, string returnNo,
            string inReturnQt, decimal returnQty,
            string inBranchId, int branchId,
            string inDestines, int destination,
            string inRetrnDet, DateTime returnDate,
            string inRefeDate, DateTime referDate,
            string inStatusId, int statusId,
            string inRermarks, string remarks);

        int ExecuteRetDelWarehouse(string procName,
            string inReturnId, int returnId,
            string inReturnQt, decimal returnQty);

        int ExecuteTenderSales(string procName,
            string inptInvoice, string returnId,
            string inReturnQt, decimal returnQty);

        int ExecuteUpdateInvoice(string procName,
            string inCustomerId, int customerId,
            string inBranchId, int branchId,
            string inVoiceId, string inVoiceid);
        decimal ExecuteRetDiscount(string procName, string inCustomerId, int customerId, string inBranchId, int branchId);
        IEnumerable<T> ExecuteSummaryParticular(string procName, string inpStarDate, DateTime starDate, string inpEndDate, DateTime endDate, string inBranchId, int branchId);

        IEnumerable<T> ExecutesDailyCredit(string procName,
            string inpBranch,   string branch,
            string inpCustomer, string customer,
            string inpRefDate, DateTime refDate);
        IEnumerable<T> ExecutesDailyCredit(string procName,
            string inpBranch, string branch,
            string inpCustomer, string customer,
            string inpStarDate, DateTime starDate,
            string inpEndDate, DateTime endDate);
        IEnumerable<T> ExecutesClient(string procName);
        IEnumerable<T> ExecutesProcedure(string procName);
    }
}