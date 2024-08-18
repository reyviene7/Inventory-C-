using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using Dapper.Contrib.Extensions;
using ServeAll.Core.Entities;
using ServeAll.Core.Helper;


namespace ServeAll.Core.Repository
{
    public class Repository<T> : IIKeyedRepository<T>, IRepository<T>, IReadOnlyRepository<T>, IReadOnlyStoredProcedure<T>, TargetClass<T> where T : class
    {
        private readonly UnitofWork _iunitofworks;
        public Repository(UnitofWork iunitofworks)
        {
            _iunitofworks = iunitofworks;
        }

        public IQueryable<T> All(string query)
        {
          return (IQueryable<T>) _iunitofworks.Connection.Query<T>(query, null, _iunitofworks.Transaction);
        }

        public IEnumerable<T> SelectAll(string query)
        {
             return _iunitofworks.Connection.Query<T>(query, null, _iunitofworks.Transaction);
        }

        public IEnumerable<T> SelectAll(string query, object parameters)
        {
            return _iunitofworks.Connection.Query<T>(query, parameters, _iunitofworks.Transaction);
        }

        public IEnumerable<T> CreateQuery(string query)
        {
            return _iunitofworks.Connection.Query<T>(query, null, _iunitofworks.Transaction).AsEnumerable();
        }

        public IEnumerable<T> DistinctBy(IEnumerable<T> source, Func<T, string> keySelector)
        {
            var seenKeys = new HashSet<string>();
            foreach (T element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

       

        public IEnumerable<T> FilterByIEnumerable(Expression<Func<T, bool>> predicate)
        {
            return _iunitofworks.Connection.GetAll<T>(_iunitofworks.Transaction, null).AsQueryable().Where(predicate);
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return _iunitofworks.Connection.GetAll<T>(_iunitofworks.Transaction, null).AsQueryable().Where(expression);
        }

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return _iunitofworks.Connection.GetAll<T>(_iunitofworks.Transaction, null).AsQueryable().Where(expression).FirstOrDefault();
        }

        public T Id(int id)
        {
            return _iunitofworks.Connection.Get<T>(id, _iunitofworks.Transaction);
        }

        public T SearchBy(string query)
        {
            return _iunitofworks.Connection.Get<T>(query, _iunitofworks.Transaction);
        }

        public T SearchBy(string query, object parameters)
        {
            return _iunitofworks.Connection.QueryFirstOrDefault<T>(query, parameters, _iunitofworks.Transaction);
        }

        public long Add(IEnumerable<T> entity)
        {
            return _iunitofworks.Connection.Insert(entity, _iunitofworks.Transaction);
        }


        public long Add(T entity)
        {
            return _iunitofworks.Connection.Insert(entity, _iunitofworks.Transaction);
        }

        public bool Update(IEnumerable<T> entity)
        {
            return _iunitofworks.Connection.Update(entity, _iunitofworks.Transaction);
        }

        public bool Update(T entity)
        {
            return _iunitofworks.Connection.Update(entity, _iunitofworks.Transaction);
        }

        public bool Delete(T entity)
        {
            return _iunitofworks.Connection.Delete(entity, _iunitofworks.Transaction);
        }

        public T GetSingle(string query, object parameters = null)
        {
            return _iunitofworks.Connection.QuerySingle<T>(query, parameters, _iunitofworks.Transaction);
        }

        public int ExeStoredProcLogin(string procedureName, string inpt1, string val1, string inpt2, string val2, string typ, int valtyp)
        {
            var param = new DynamicParameters();
            param.Add(inpt1, val1);
            param.Add(inpt2, val2);
            param.Add(typ, valtyp);
            param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procedureName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>("@RESULT");
        }

        public int ExeStoredProcLogin(string procedureName, string inpt1, string val1, string inpt2, string val2, string input3, string val3)
        {
            var param = new DynamicParameters();
            param.Add(inpt1, val1);
            param.Add(inpt2, val2);
            param.Add(input3, val3);
            param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procedureName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>("@RESULT");
        }

        public SqlByte ExecStoredProc(string procName, string inpt, string val)
        {
            var param = new DynamicParameters();
            param.Add(inpt, val);
            param.Add("@hassPass", dbType: DbType.Binary, direction: ParameterDirection.Output, size: 5215585);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<SqlByte>("@hassPass");
        }

        public string ExecLoginUser(string procName, string userName, string userValue, string userType, int typValue)
        {
            var param = new DynamicParameters();
            var passwordOutParamName = "@p_password";
            param.Add(userName, userValue);
            param.Add(userType, typValue);
            param.Add(passwordOutParamName, dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);

            // Retrieve the output parameter value
            return param.Get<string>(passwordOutParamName);
        }

        public int ExecCounterStored(string procName, string inpInvoice, string valInvoice,
                                  string inpBarcode, string valBarcode,
                                  string inpBranch, int branchId,
                                  string inpCustomer, int customerId,
                                  string inpUser, int userId)
        {
            var param = new DynamicParameters();
            var counterOutParamName = "@p_counter";
            param.Add(inpInvoice, valInvoice);
            param.Add(inpBarcode, valBarcode);
            param.Add(inpBranch, branchId);
            param.Add(inpCustomer, customerId);
            param.Add(inpUser, userId);
            param.Add(counterOutParamName, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(counterOutParamName);
        }

        public decimal ExecPosTotalTemp(string procName, string inpCustomer, int customerId, string inpInvoice, string invoice, string inpBranch, int branchId)
        {
            var param = new DynamicParameters();
            var par = new Dictionary<string, object>();
            par.Add(inpCustomer, customerId);
            par.Add(inpInvoice, invoice);
            par.Add(inpBranch, branchId);
            param.AddDynamicParams(par);
            param.Add(StoredProcedure.HasValue, dbType: DbType.Decimal, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<decimal>(StoredProcedure.HasValue);
        }

        public int ExecCancelTemp(string procName,   string inpInvoice, string valInvoice, 
                                  string inpBarcode, string valBarcode, 
                                  string inpBranch,  int branchId, 
                                  string inpCustomer, int customerId)
        {
            var param = new DynamicParameters();
            param.Add(inpInvoice,   valInvoice);
            param.Add(inpBarcode,   valBarcode);
            param.Add(inpBranch,    branchId);
            param.Add(inpCustomer,  customerId);
            param.Add(StoredProcedure.HasIntValue, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(StoredProcedure.HasIntValue);
        }

        public void ExecAddItemDiscount(
            string procedureName,
            string salesId,
            int idValue,
            string discount,
            decimal discountValue
            )
        {
            var param = new DynamicParameters();
            param.Add(salesId, idValue);
            param.Add(discount, discountValue);
            _iunitofworks.Connection.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
        }

        public int ExecDeleteTemp(
            string procName,
            string invoice,
            string invoiceValue,
            string barcode,
            string barcodeValue,
            string branch,
            int branchIdValue,
            string customerId,
            int customerIdValue,
            string inpQuantity,
            decimal quantity
            )
        {
            var param = new DynamicParameters();
         
            param.Add(invoice, invoiceValue);
            param.Add(barcode, barcodeValue);
            param.Add(branch, branchIdValue);
            param.Add(customerId, customerIdValue);
            var counterOutParamName = "@p_status";
            param.Add(counterOutParamName, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(counterOutParamName);
        }
        public IEnumerable<T> ExecSelectAll(string procName,string inpBranch, int branchId, string inpCustomer, int customerId)
        {
            var param = new DynamicParameters();
            param.Add(inpBranch, branchId);
            param.Add(inpCustomer, customerId);
            return _iunitofworks.Connection.Query<T>(procName, param, null, false, null, CommandType.StoredProcedure).AsEnumerable();
        }
 

        public int ExecInsertTemp(string procName, string inpInvoiceId, string vInvoiceId, string inpProductId, int vProductId, string inpBarcode, string vBarcode, string inpQuantity, int vQuantity, string inpUnitPrice, decimal vUnitPrice, string inpTax, decimal vTax, string inpDiscount, decimal vDiscount, string inpGross, decimal vGross, string inpNetSales, decimal vNetSales, string inpCustomerId, int vCustomerId, string inpUserId, int vUserId, string inpBranchId, int vBranchId, string inpPurchaseOn, DateTime vPurchaseOn)
        {
            var parms = new Dictionary<string, object>
            {
                {inpInvoiceId, vInvoiceId},
                {inpProductId, vProductId},
                {inpBarcode, vBarcode},
                {inpQuantity, vQuantity},
                {inpUnitPrice, vUnitPrice},
                {inpTax, vTax},
                {inpDiscount, vDiscount},
                {inpGross, vGross},
                {inpNetSales, vNetSales},
                {inpCustomerId, vCustomerId},
                {inpUserId, vUserId},
                {inpBranchId, vBranchId},
                {inpPurchaseOn, vPurchaseOn}
            };
            var param = new DynamicParameters();
            param.AddDynamicParams(parms);
            param.Add(StoredProcedure.HasIntValue, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(StoredProcedure.HasIntValue);

        }
        public int ExecInsertPayment(string procName, 
                                     string inpCustomerId, int customerId, 
                                     string inpCreditId,   int creditId, 
                                     string inpInvoiceId,  string invoiceId, 
                                     string inpBranchId, int branchId, 
                                     string inpAmountPay, decimal amountPay, 
                                     string inpServiceNum, string serviceNum, 
                                     string inpRefDate, DateTime refDate)
        {
            
            var parm = new Dictionary<string, object>
            {
                {inpCustomerId, customerId},
                {inpCreditId,   creditId},
                {inpInvoiceId,  invoiceId },
                {inpBranchId,   branchId },
                {inpAmountPay,  amountPay },
                {inpServiceNum, serviceNum },
                {inpRefDate,    refDate }
            };
            var param = new DynamicParameters();
            param.AddDynamicParams(parm);
            param.Add(StoredProcedure.WithValue, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(StoredProcedure.WithValue);
        }

        public int ExecGetInventoryQty(string procedureName, string inpProcId, int productId, string inpBranId, int branchId,
            string inpDeleNo, string deliveryNo, string inpReceNo, string receiptNo)
        {
            var parDic = new Dictionary<string, object>
            {
                {inpProcId, productId},
                {inpBranId, branchId },
                {inpDeleNo, deliveryNo },
                {inpReceNo, receiptNo }
            };
            var param = new DynamicParameters();
            param.AddDynamicParams(parDic);
            param.Add(StoredProcedure.WithValue, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procedureName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(StoredProcedure.WithValue);
        }

        public int ExecuteFinger(string procedureName, string inEmployeeId, int employeeId, string inFingerIndex, int fingerIndex,
            string inFingerBytes, string fingerBytes)
        {
            var parDic = new Dictionary<string, object>
            {
                {inEmployeeId, employeeId },
                {inFingerIndex, fingerIndex },
                {inFingerBytes, fingerBytes }
            };
            var param = new DynamicParameters();
            param.AddDynamicParams(parDic);
            param.Add(StoredProcedure.ReturnResult, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procedureName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(StoredProcedure.ReturnResult);
        }

        public int ExecuteReturnWarehouse(
            string procName, 
            string inReturnId, int returnId, string inReturnCd, string returnCd,
            string inProdctId, int productId, string inReturnNo, string returnNo, string inReturnQt, decimal returnQty,
            string inBranchId, int branchId, string inDestines, int destination, string inRetrnDet, DateTime returnDate,
            string inRefeDate, DateTime referDate, string inStatusId, int statusId, string inRermarks, string remarks,
            string inInventry, int inventoryId)
        {
            var paramDic = new Dictionary<string, object>
            {
                {inReturnId, returnId},
                {inReturnCd, returnCd},
                {inProdctId, productId},
                {inReturnNo, returnNo},
                {inReturnQt, returnQty},
                {inBranchId, branchId},
                {inDestines, destination},
                {inRetrnDet, returnDate},
                {inRefeDate, referDate},
                {inStatusId, statusId},
                {inRermarks, remarks},
                {inInventry, inventoryId}
            };
            var param = new DynamicParameters();
            param.AddDynamicParams(paramDic);
            param.Add(StoredProcedure.ReturnResult, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(StoredProcedure.ReturnResult);
        }

        public int ExecuteRetUpdWarehouse(string procName, string inReturnId, int returnId, string inReturnCd, string returnCd,
            string inProdctId, int productId, string inReturnNo, string returnNo, string inReturnQt, decimal returnQty,
            string inBranchId, int branchId, string inDestines, int destination, string inRetrnDet, DateTime returnDate,
            string inRefeDate, DateTime referDate, string inStatusId, int statusId, string inRermarks, string remarks)
        {
            var paramDic = new Dictionary<string, object>
            {
                {inReturnId, returnId},
                {inReturnCd, returnCd},
                {inProdctId, productId},
                {inReturnNo, returnNo},
                {inReturnQt, returnQty},
                {inBranchId, branchId},
                {inDestines, destination},
                {inRetrnDet, returnDate},
                {inRefeDate, referDate},
                {inStatusId, statusId},
                {inRermarks, remarks}
            };
            var param = new DynamicParameters();
            param.AddDynamicParams(paramDic);
            param.Add(StoredProcedure.ReturnResult, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(StoredProcedure.ReturnResult);
        }

        public int ExecuteRetDelWarehouse(string procName, string inReturnId, int returnId, string inReturnQt, decimal returnQty)
        {
            var paramDic = new Dictionary<string, object>
            {
                {inReturnId, returnId },
                {inReturnQt, returnQty }
            };
            var param = new DynamicParameters();
            param.AddDynamicParams(paramDic);
            param.Add(StoredProcedure.ReturnResult, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(StoredProcedure.ReturnResult);
        }

        public int ExecuteUpdateInvoice(string procName, string inCustomerId, int customerId, string inBranchId, int branchId,
            string inVoiceId, string inVoiceid)
        {
            var paramDic = new Dictionary<string, object>
            {
                {inCustomerId, customerId },
                { inBranchId, branchId },
                { inVoiceId, inVoiceid}
            };
            var param = new DynamicParameters();
            param.AddDynamicParams(paramDic);
            param.Add(StoredProcedure.ReturnResult, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(StoredProcedure.ReturnResult);

        }

        public decimal ExecuteRetDiscount(string procName, string inCustomerId, int customerId, string inBranchId, int branchId)
        {
            var paramDic = new Dictionary<string, object>
            {
                {inCustomerId, customerId },
                { inBranchId, branchId } 
            };
            var param = new DynamicParameters();
            var discountParam = "@p_discount";
            param.AddDynamicParams(paramDic);
            param.Add(discountParam, dbType: DbType.Decimal, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<decimal>(discountParam);
        }

        public IEnumerable<T> ExecuteSummaryParticular(string procName, string inpStarDate, DateTime starDate, string inpEndDate, DateTime endDate, string inBranchId, int branchId)
        {
            var paramDic = new Dictionary<string, object>
            {
                {inpStarDate, starDate },
                {inpEndDate, endDate },
                {inBranchId, branchId}
            };
            var param = new DynamicParameters();
                param.AddDynamicParams(paramDic);
           return _iunitofworks.Connection.Query<T>(procName, param, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<T> ExecutesDailyCredit(string procName, string inpBranch, string branch, string inpCustomer, string customer,
            string inpRefDate, DateTime refDate)
        {
            var paramDic = new Dictionary<string, object>()
            {
                {inpBranch, branch},
                {inpCustomer, customer},
                {inpRefDate, refDate}
            };
            var param = new DynamicParameters();
            param.AddDynamicParams(paramDic);
            return _iunitofworks.Connection.Query<T>(procName, param, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<T> ExecutesDailyCredit(string procName, string inpBranch, string branch, string inpCustomer, string customer,
            string inpStarDate, DateTime starDate, string inpEndDate, DateTime endDate)
        {
            var paramDic = new Dictionary<string, object>
            {
                {inpCustomer, customer },
                {inpBranch, branch },
                {inpStarDate, starDate },
                {inpEndDate, endDate }
            };
            var param = new DynamicParameters();
            param.AddDynamicParams(paramDic);
            return _iunitofworks.Connection.Query<T>(procName, param, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<T> ExecutesClient(string procName)
        {
            return _iunitofworks.Connection.Query<T>(procName, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<T> ExecutesProcedure(string procName)
        {
            return _iunitofworks.Connection.Query<T>(procName, null, commandType: CommandType.StoredProcedure);
        }

        public T getVAlue(string query)
        {
            return _iunitofworks.Connection.Get<T>(query, _iunitofworks.Transaction);
        }

        public T getValue(string query)
        {
            return _iunitofworks.Connection.Get<T>(query, _iunitofworks.Transaction);
        }

        public int ExecUpdateTemp(
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
            decimal quantity)
        {
            var param = new DynamicParameters();
            var counterOutParamName = "@p_status";
            param.Add(invoice, invoiceValue);
            param.Add(barcode, barcodeValue);
            param.Add(branch, branchIdValue);
            param.Add(customerId, customerIdValue);
            param.Add(productId, productIdValue);
            param.Add(inpQuantity, quantity);
            param.Add(counterOutParamName, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _iunitofworks.Connection.Execute(procName, param, null, null, CommandType.StoredProcedure);
            return param.Get<int>(counterOutParamName);
        }

        public int ExecuteTenderSales(string procName, string inptInvoice, string returnId, string inReturnQt, decimal returnQty)
        {
            throw new NotImplementedException();
        }
    }
}