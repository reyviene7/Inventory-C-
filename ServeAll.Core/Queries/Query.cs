namespace ServeAll.Core.Queries
{
    public class Query
    {
        public const string DefaultCode = @"00-00-00";
        public const string AllBranch = @"select * FROM view_branch;";
        public const string AllWarehouse = @"SELECT * FROM view_warehouse";
        public const string AllSpecificBranch = @"SELECT  
                                                 BranchDetails FROM Branch";
        public const string AllSpecificCustomer = @"SELECT Name FROM view_customers";
        public const string AllEmployees = @"SELECT EmployeeId ,
		                                    EmployeeCode , 
		                                    FirstName, 
		                                    LastName, 
		                                    MiddleInitial , 
		                                    Gender, 
		                                    Birthdate, 
		                                    CivilStatus , 
		                                    Phone, 
		                                    Mobile, 
		                                    EmailAddress , 
		                                    EmployeeAddress , 
		                                    ProventialAddress , 
		                                    SSSNumber , 
		                                    PhilHealth, 
		                                    Position, 
		                                    Department, 
		                                    HireDate, 
		                                    DateRegister 
                                     FROM Employees";

        public const string viewProfile = @"SELECT profile_id,
                                                contact_id,
                                                address_id,        
                                                profile_code,
                                                last_name,
                                                first_name,
                                                middle_initial,
                                                gender,
                                                birthdate,
                                                civil_status,
                                                telephone_number,
                                                mobile_number,
                                                email_address,
                                                barangay,
                                                street,
                                                city,
                                                province,
                                                zip_code,
                                                country,
                                                user_id,
                                                sss_number,
                                                phil_health,
                                                position,
                                                department_id,
                                                hire_date,
                                                date_register
                                                FROM view_profile";

        public const string AllCompany = @"SELECT company_id,
	                                       company_code, 
	                                       company_name, 
	                                       barangay,
                                           street,
                                           city,
                                           province,
                                           zip_code,
                                           country,
                                           telephone_number,
                                           mobile_number,
                                           email_address,
                                           web_url,
                                           fax_number,
	                                       company_type, 
	                                       date_register
                                     FROM view_company";

        public const string AllCustomers = @"SELECT customer_id, customer_code, customer_name, gender, email_address, telephone_number, mobile_number, fax_number, barangay, street, province, city, zip_code, client_type, date_register FROM view_customers";
        public const string PosCustomer = @"SELECT
                                              customer_id,
                                              customer_name
                                            FROM view_poscustomers";
        public const string PosProducts = @"SELECT code as Code, item as Item, qty as Qty, retail_price, wholesale, status, branch FROM view_product_inventory";
        public const string AllProductList = @"SELECT ProductId, Code, Name, RetailPrice, Status FROM view_productlist ORDER BY Code ASC";
        public const string AllInventoryList = "SELECT inventory_id, product_code, product_name, quantity, status, branch_details FROM view_inventoryList";
        public const string AllSupplier = @"SELECT supplier_id,
                                              supplier_code,
                                              supplier_name,
                                              gender,
                                              email_address,
                                              telephone_number,
                                              fax_number,
                                              mobile_number,
                                              barangay,
                                              street,
                                              province,
                                              zip_code,
                                              country,
                                              company_name,
                                              date_register
                                          FROM view_supplier";
        public const string AllManufacture = @"SELECT manufacture_id,
                                              profile_code,
                                              last_name,
                                              gender,
                                              email_address,
                                              telephone_number,
                                              mobile_number,
                                              fax_number,
                                              barangay,
                                              street,
                                              city,
                                              province,
                                              zip_code,
                                              country,
                                              company_id,
                                              date_egister
                                          FROM view_manufacture";

        public const string AllProductImage = @"SELECT	image_id, 
		                                                image_code, 
		                                                title, 
		                                                img_type, 
		                                                img_location, 
		                                                branch_id 
                                                FROM product_image";
        public const string AllCategory = @"SELECT category_id, 
	                                               category_code, 
	                                               category_details, 
	                                               image_id, 
	                                               date_register
                                             FROM category";

        public const string AllCategoryImage = @"SELECT * FROM view_category_image";

        public const string AllProducts = @"SELECT product_id
                                                  ,product_code
                                                  ,product_name
                                                  ,category_details
                                                  ,supplier_name
                                                  ,stock_code
                                                  ,brand
                                                  ,model
                                                  ,made
                                                  ,serial_number
                                                  ,tare_weight
                                                  ,net_weight
												  ,trade_price 
												  ,retail_price
												  ,wholesale
                                                  ,status_details
                                                  ,date_register
                                              FROM view_product";

        public const string AllBindProduct = @"SELECT product_id
                                                  ,product_code
                                                  ,product_name
                                                  ,category_details
                                                  ,supplier_name
                                                  ,stock_code
                                                  ,brand
                                                  ,model
                                                  ,made
                                                  ,serial_number
                                                  ,tare_weight
                                                  ,net_weight
												  ,trade_price 
												  ,retail_price
												  ,wholesale
                                                  ,status_details
                                                  ,date_register
                                              FROM view_product";

        public const string AllItemNotInDepot = "SELECT ProductId, Code,Name, Category, Supplier, StockCode, Brand, Model, Made, Serial, TareWeight, NetWeight, TradePrice, RetailPrice, WholeSale, Status, Register FROM view_products WHERE ProductId NOT IN(SELECT ProductId FROM Products WHERE Name LIKE '%LPG%')";
        public const string AllItemFromDepots = "SELECT ProductId, Code,Name, Category, Supplier, StockCode, Brand, Model, Made, Serial, TareWeight, NetWeight, TradePrice, RetailPrice, WholeSale, Status, Register FROM view_products WHERE Name LIKE '%LPG%'";
        public const string AllViewProducts = "SELECT * FROM view_product";
        public const string AllViewImageProduct = "SELECT * FROM view_image_product";

        public const string AllInventory = @"SELECT * FROM view_inventory";
        public const string AllProductCategory = @"SELECT * FROM view_product_category";
        public const string AllProductStatus = @"SELECT status_id, status FROM product_status";
        public const string AllUsers = @"SELECT user_id,
                                                user_code,
		                                        username, 
		                                        password, 
		                                        role_id, 
		                                        profile_id
                                         FROM users";
        public const string AllEmployeeImages = @"SELECT ImageId, 
	                                               ImageCode, 
	                                               Image, 
	                                               Title, 
	                                               ImgType, 
	                                               ImgLocation, 
	                                               ImgHeight, 
	                                               ImgWidth
                                             FROM EmployeeImages";
        public const string AllMerchandiseStatus = @"SELECT status_id, status_details FROM merchandise_status";
        public const string AllCustomerType = @"SELECT type_id, client_type FROM customer_type";
        public const string AllRoleTypes = @"SELECT role_type FROM roles";

        public const string AllFullName = @"SELECT employee_id,
		                                        employee_code, 
		                                        full_name,
		                                        gender, 
		                                        birthdate, 
		                                        civil_status, 
		                                        phone, 
		                                        mobile, 
		                                        email, 
		                                        address,
                                                sss_number, 
		                                        philhealth, 
		                                        position, 
		                                        department, 
		                                        date_hired, 
		                                        date_registered
                                          FROM view_employees";
        public const string AllCustomerCredit = @"SELECT id, credit_code, name, credit_limit, credit_used, balance FROM view_customer_credit ORDER BY id DESC";



        public const string list_customer_credit = "SELECT id, code, customer, c_limit, used, balance, address, client_type FROM view_customer_credit_list";
        public const string AllRouteLogId = @"SELECT route_log_id FROM route_log ORDER BY route_log_id DESC LIMIT 1";
        public const string AllWarranty = @"select  warranty_id, warranty_type, start_date, end_date FROM posWizards.warranty";
        
        public const string LastInvoiceCredit = @"SELECT ParticularId FROM CreditParticular ORDER BY ParticularId DESC";
        public const string AllTempSales = @"SELECT SaleId, InvoiceId, Barcode, Name, QTY, UnitPrice, Discount, Gross, NetSales, BranchId, CustomerId FROM view_tempSales";
        public const string AllSales = "SELECT id, invoice, barcode, item, qty, price, discount, gross, net, customer_id, branch_id, date FROM view_sales_particular ORDER BY id DESC";
        public const string AllTransact = "SELECT Id, InvoiceId, Customer, AmountDue, PaidAmount, Discount, NetSales, BranchId, Receipt, RefDate FROM view_sales ORDER BY Id DESC";
        public const string AllWarrantyStatus = "SELECT StatusId, Details FROM WarrantyStatus";
        public const string AllSalesWarranty = "SELECT Id,InvoiceId, ReceiptNo, ItemName, SerailNumber, Warranty, Customer, BranchId, StartDate, EndDate, Status FROM view_SalesWarranty";

        public const string AllUnderWarranty = "SELECT Id, Barcode, Product, Qty, Retail, LastCost, Branch, Warranty, Status FROM view_under_warranty";
        public const string AllPurchaseWarranty = "SELECT Id, Invoice, Barcode, Product, Quantity,Price, Customer, Branch, WarrantyOn, Expiration, NoDays FROM view_product_warranty";
        public const string AllCredit = "SELECT * FROM Credit";
        public const string CountAllCreditCustomer = "SELECT customer_credit_id FROM customer_credit";
        public const string CountAllServiceNumber = "SELECT ServiceNumber FROM Credit";
        //DEPOT
        public const string SelectAllDepot = "SELECT Id, Code, Item, Qty, DeliveryNo, ReceiptNo, Branch, LastCost, OnOrder, Purchase, RefDate, Warranty, Status FROM view_depot ORDER BY Id DESC";
        public const string SelectAllWareHouse = "SELECT warehouse_code, warehouse_name, full_address, contact_name, telephone_number, mobile_number, mobile_secondary, email_address, web_url, fax_number FROM view_warehouse ORDER BY warehouse_code ASC;";
        public const string SelectAllBranchDelivery = "SELECT Id, Code, Item, Qty, Delivery, Receipt, Branch, Warranty, Status,RefDate, WareHouseId FROM view_branchdelivery ORDER BY Id DESC";
        public const string SelectAllBranchExcWareH = "SELECT BranchDetails FROM Branch WHERE BranchId NOT IN (SELECT BranchId FROM Branch WHERE BranchDetails = 'Warehouse')";
        public const string SelectAllFingerPrints = "SELECT FingerId, EmployeeId, FingerIndex, FingerBytes FROM Finger ORDER BY FingerIndex DESC";
        public const string SelectAllReturnWareHs = "SELECT return_id, return_code, product_code, return_number, return_quantity, branch_code, destination, return_date, status_id, remarks, inventory_code FROM view_return_warehouse ORDER BY return_id DESC";
        public const string SelectAllProductId = "SELECT product_id FROM view_product_id";
        public const string SelectAllStockMovement = "SELECT * FROM stock_movement";
        public const string SelectStockMovementList = "SELECT * FROM view_stock_movement";
        public const string SelectDeliveryList = "SELECT * FROM view_delivery_list";
        public const string SelectCountReturnNo = "SELECT return_id, return_number FROM view_return_warehouse";
        public const string SelectCountDepotRet = "SELECT ReceiptNo FROM WareHouse";
        public const string SelectCountDepotDel = "SELECT DeliveryNo FROM WareHouse";
        public const string SelectCountDepotsId = "SELECT Id, Code, DeliveryNo FROM view_return_depot";
        public const string SelectReturnDepot = "SELECT Id, Code, Item, DeliveryNo, QtyStock, Qty, Origin, ToDepot, Delivery, RefDate, Status, Remarks, WareHouse FROM view_return_depot";
        public const string SelectWareHouseDepot = @"SELECT Id, Code, Item, DeliveryNo, WareHouse, Origin, Delivery, Ref, Status, Remarks FROM view_return_warehouse_depot WHERE Item LIKE '%LPG%' ORDER BY Id DESC";
        public const string SelectReturnDepotDel = "SELECT Id, Code, Item, Qty, ReturnNo, Origin, Destination, Delivery, RefDate, Status, Remarks, WareHouseId FROM view_return_delivery_depot";
        public const string SelectReportDepotDelivery = "SELECT * FROM report_depot_delivery";
        public const string SelectReportWareHouseItem = "SELECT Id, Item, Qty, Delivery, Branch, LastCost, RetailPrice, Purchase, Warranty, Status FROM report_warehouse_item";
        public const string SelectReportWareHouseDelr = "SELECT Id, Item, Qty, Delivery, Branch, LastCost, RetailPrice, RefDate, Warranty, Status FROM report_branch_delivery";
        public const string SelectReportReturnWarehos = "SELECT  Id,Item, Delivery, Qty, Origin, RetailPrice, RetDate, Status, Remarks FROM report_return_warehouse";
        public const string SelectReportReturnDepotDl = "SELECT * FROM report_return_delivery_depot";
        public const string SelectReportAllItem = "SELECT ProductId, Code, Name, RetailPrice, TradePrice FROM Products";
        public const string getContactId = @"SELECT contact_id FROM contact";
        public const string getAddressId = @"SELECT address_id FROM address";
        public const string getCustomerId = @"SELECT customer_id FROM customers";
        public const string getLastInvoiceId = @"SELECT particular_id FROM sales_particular ORDER BY particular_id DESC";
        public const string getUserId = "SELECT user_id FROM users";
        public const string getProfileName = "SELECT last_name,first_name,middle_initial FROM profile";
        public const string getProfileId = "SELECT profile_id, name FROM view_profile_entities";
        public const string getViewUser = "SELECT user_id, user_code, name, username, role_type FROM view_user";
        public const string getProductDetails = "select code, item, qty, retail_price, wholesale, status, branch from view_product_inventory where code = @barcode and branch = @branch and status = @status and qty >= 1";
        public const string getCustomerList = "select customer_id, customer_name from view_poscustomers";
        public const string getCustomerCurrentCredit = "select * FROM customer_credit where customer_id = @customerId";
        public const string getTempCounterSales = "SELECT particular_id FROM temp_sales WHERE invoice_id = @invoiceId AND barcode = @barcode AND customer_id = @customerId AND user_id = @userId AND branch_id = @branchId";
        public const string getLastProductIdQuery = "SELECT COUNT(product_id) as product_id FROM products";
        public const string getLastInventoryQuery = "SELECT MAX(inventory_id) as inventory_id FROM inventory";
        public const string getLastInventoryCodeQuery = "SELECT MAX(inventory_code) AS inventory_code FROM inventory";
        public const string getLastInventoryDeliveryQuery = "SELECT MAX(delivery_code) AS delivery_code FROM inventory";
        public const string getLastCategoryIdQuery = "SELECT COUNT(category_id) as category_id FROM category";
        public const string getLastImageIdQuery = "SELECT COUNT(image_id) as image_id FROM product_image";
    }
}