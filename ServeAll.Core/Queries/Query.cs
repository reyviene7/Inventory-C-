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
                                                FROM view_profile ORDER BY profile_id DESC";

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
        public const string AllInventoryList = "SELECT * FROM view_inventory";
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
                                             FROM category ORDER BY category_id DESC";

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
        public const string AllViewProducts = "SELECT * FROM view_product ORDER BY product_id DESC";
        public const string AllViewServiceImages = "SELECT * FROM view_service_images ORDER BY image_id DESC";
        public const string AllViewProfileImages = @"SELECT * FROM profile_image ORDER BY image_id DESC";
        public const string AllProductWarehouse = @"SELECT * FROM view_request_product";
        public const string AllQuantityWarehouse = @"SELECT * FROM view_request_quantity";
        public const string AllSupplierWarehouse = @"SELECT * FROM view_request_supplier";
        public const string AllRequestCategory = @"SELECT * FROM view_request_category";
        public const string AllViewImageProduct = "SELECT * FROM view_image_product";
        public const string AllWarehouseStatus = @"SELECT * FROM warehouse_status ORDER BY status_details ASC";
        public const string AllUserNames = @"SELECT username FROM users ORDER BY username ASC";
        public const string AllUserImage = "SELECT * FROM user_image";
        public const string AllViewUserImage = "SELECT * FROM view_user_image";
        public const string AllStaff = @"SELECT * FROM view_request_staff ORDER BY staff ASC";
        public const string AllDeliveryStatus = @"SELECT * FROM delivery_status ORDER BY delivery_status ASC";
        public const string AllPaymentMethod = @"SELECT method_name FROM payment_method";
        public const string AllWarehouseLocation = @"SELECT * FROM location ORDER BY location_code ASC";
        public const string AllServiceStatus = @"SELECT * FROM service_status order by status_name ASC";
        public const string AllWarehouseList = @"SELECT warehouse_id, warehouse_name FROM warehouse";
        public const string AllInventory = @"SELECT * FROM view_inventory ORDER BY inventory_id DESC";
        public const string AllWarehouseProduct = @"SELECT * FROM view_productlist ORDER BY product_id DESC";
        public const string AllSalesPart = @"SELECT * FROM view_sales_particular ORDER BY id DESC";
        public const string AllSalesParticularByBranch = "SELECT * FROM view_sales_particular WHERE branch = @branchName ORDER BY id DESC";
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
        public const string CountAllWarehouses = "SELECT COUNT(warehouse_id) as warehouse_id FROM warehouse";
        public const string SelectAllDepot = "SELECT Id, Code, Item, Qty, DeliveryNo, ReceiptNo, Branch, LastCost, OnOrder, Purchase, RefDate, Warranty, Status FROM view_depot ORDER BY Id DESC";
        public const string SelectAllWareHouse = "SELECT warehouse_code, warehouse_name, full_address, contact_name, telephone_number, mobile_number, mobile_secondary, email_address, web_url, fax_number FROM view_warehouse ORDER BY warehouse_code ASC;";
        public const string SelectAllBranchDelivery = "SELECT Id, Code, Item, Qty, Delivery, Receipt, Branch, Warranty, Status,RefDate, WareHouseId FROM view_branchdelivery ORDER BY Id DESC";
        public const string SelectAllBranchExcWareH = "SELECT branch_details FROM branch WHERE branch_id NOT IN (SELECT branch_id FROM branch WHERE branch_details = 'warehouse')";
        public const string SelectAllFingerPrints = "SELECT FingerId, EmployeeId, FingerIndex, FingerBytes FROM Finger ORDER BY FingerIndex DESC";
        public const string SelectAllReturnWareHs = "SELECT return_id, return_code, product_code, product_name, return_number, return_quantity, branch_details, destination, return_date, update_on, status, remarks, inventory_code FROM view_return_warehouse ORDER BY return_id DESC";
        public const string SelectAllProductId = "SELECT product_id FROM view_product_id";
        public const string SelectAllStockMovement = "SELECT * FROM stock_movement";
        public const string SelectStockMovementList = "SELECT * FROM view_stock_movement";
        public const string SelectCountReturnNo = "SELECT return_id, return_number FROM view_return_warehouse";
        public const string SelectCountDepotRet = "SELECT ReceiptNo FROM WareHouse";
        public const string SelectCountDepotDel = "SELECT DeliveryNo FROM WareHouse";
        public const string SelectCountDepotsId = "SELECT Id, Code, DeliveryNo FROM view_return_depot";
        public const string SelectReturnDepot = "SELECT Id, Code, Item, DeliveryNo, QtyStock, Qty, Origin, ToDepot, Delivery, RefDate, Status, Remarks, WareHouse FROM view_return_depot";
        public const string SelectWareHouseDepot = @"SELECT Id, Code, Item, DeliveryNo, WareHouse, Origin, Delivery, Ref, Status, Remarks FROM view_return_warehouse_depot WHERE Item LIKE '%LPG%' ORDER BY Id DESC";
        public const string SelectReturnDepotDel = "SELECT Id, Code, Item, Qty, ReturnNo, Origin, Destination, Delivery, RefDate, Status, Remarks, WareHouseId FROM view_return_delivery_depot";
        public const string SelectReportDepotDelivery = "SELECT * FROM report_depot_delivery";
        public const string SelectReportWareHouseItem = "SELECT inventory_id, product_name, quantity_in_stock, sku, warehouse_name, cost_per_unit, last_cost_per_unit, updated_at, status_details FROM report_warehouse_inventory";
        public const string SelectReportWareHouseDelr = "SELECT delivery_id, product_name, quantity_in_stock, delivery_code, branch_details, last_cost_per_unit, retail_price, delivery_date, status_details FROM report_warehouse_delivery";
        public const string SelectReportReturnWarehos = "SELECT  return_id, product_name, return_quantity, return_number, branch_details, retail_price, return_date, status, remarks FROM report_return_warehouse";
        public const string SelectReportReturnDepotDl = "SELECT * FROM report_return_delivery_depot";
        public const string SelectReportAllItem = "SELECT inventory_id, product_code, product_name, quantity, trade_price, retail_price, status FROM view_inventoryList";
        public const string SelectReportDailyExpenses = "SELECT * FROM view_daily_expenses";
        public const string SelectReportProduct = "SELECT product_id, product_code, product_name, trade_price, retail_price FROM report_product_list";
        public const string SelectReportSales = "SELECT sale_id, customer_name, amount_due, paid_amount, gross, discount, net_sales, branch_details, receipt_number, sale_date  FROM report_sales";
        public const string SelectReportService = "SELECT service_id, service_name, service_details, service_charges, category_details, service_commission, full_name, status_name, service_date FROM report_service";
        public const string SelectReportPayment = "SELECT payment_id, amount_due, amount_paid, remaining_balance, payment_method, customer_name, branch_details, credit_code, receipt_number, payment_date FROM report_payment";
        public const string SelectReportCredit = "SELECT credit_id, customer_name, amount_credit, paid_amount, discount, net_sales, branch_details, service_number, credit_date  FROM report_credit";
        public const string SelectReportSalesParticular = "SELECT particular_id, product_name, unit_price, quantity, gross, net_sales, branch_details, customer_name, status_name, purchase_on  FROM report_sales_particular";
        public const string SelectReportServiceParticular = "SELECT particular_id, service_name, service_charge, tax, discount, gross, net_sales, customer_name, status_name, service_on  FROM report_service_particular";
        public const string SelectReportCreditParticular = "SELECT particular_id, product_name, quantity, unit_price, gross, net_sales, branch_details, customer_name, purchase_on  FROM report_credit_particular";
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
        public const string getWarehouseDeliveryById = "SELECT * FROM view_warehouse_delivery WHERE delivery_id = @deliveryId";
        public const string getAcceptedDeliveryById = "SELECT * FROM view_accepted_delivery WHERE received_id = @receivedId";
        public const string getReturnById = "SELECT * FROM view_return_warehouse WHERE return_id = @returnId";
        public const string getCreditById = "SELECT * FROM view_credit_sales WHERE id = @creditId";
        public const string getPaymentById = "SELECT * FROM view_payment WHERE payment_id = @paymentId";
        public const string getMethodById = "SELECT * FROM payment_method WHERE payment_method_id = @methodId";
        public const string getTempCounterSales = "SELECT particular_id FROM temp_sales WHERE invoice_id = @invoiceId AND barcode = @barcode AND customer_id = @customerId AND user_id = @userId AND branch_id = @branchId";
        public const string getLastProductIdQuery = "SELECT COUNT(product_id) as product_id FROM products";
        public const string getLastProfileIdQuery = "SELECT COUNT(profile_id) as profile_id FROM profile";
        public const string getLastProfileImgQuery = "SELECT COUNT(image_id) as image_id FROM profile_image";
        public const string getLastContactIdQuery = "SELECT COUNT(contact_id) as contact_id FROM contact";
        public const string getLastAddressIdQuery = "SELECT COUNT(address_id) as address_id FROM address";
        public const string getLastServiceIdQuery = "SELECT COUNT(service_id) as service_id FROM services";
        public const string getLastServiceImgQuery = "SELECT COUNT(image_id) as image_id FROM service_image";
        public const string getLastInventoryQuery = "SELECT MAX(inventory_id) as inventory_id FROM inventory";
        public const string getLastReturnQuery = "SELECT MAX(return_id) as return_id FROM return_warehouse";
        public const string getLastReturnDelQuery = "SELECT MAX(return_number) as return_number FROM return_warehouse";
        public const string getLastInventoryCodeQuery = "SELECT MAX(inventory_code) AS inventory_code FROM inventory";
        public const string getLastInventoryDeliveryQuery = "SELECT MAX(delivery_code) AS delivery_code FROM inventory";
        public const string getLastWarehouseDeliveryQuery = "SELECT MAX(delivery_code) AS delivery_code FROM warehouse_delivery";
        public const string getLastReceiptQuery = "SELECT MAX(receipt_number) AS receipt_number FROM warehouse_delivery";
        public const string getLastCategoryIdQuery = "SELECT COUNT(category_id) as category_id FROM category";
        public const string getLastImageIdQuery = "SELECT COUNT(image_id) as image_id FROM product_image";
        public const string getLastWarehousId = "SELECT COUNT(warehouse_id) as warehouse_id FROM warehouse";
        public const string getLastBranchCodeQuery = "SELECT MAX(branch_code) AS branch_code FROM branch";
        public const string getWarehouseInventory = @"SELECT inventory_id,
                                                        product_code,
                                                        sku,
                                                        quantity_in_stock,
                                                        reorder_level,
                                                        location_code,
                                                        warehouse_name,
                                                        supplier_name,
                                                        last_stocked_date,
                                                        last_ordered_date,
                                                        expiration_date,
                                                        cost_per_unit,
                                                        last_cost_per_unit,
                                                        total_value,
                                                        status_details,
                                                        created_at,
                                                        updated_at
                                                    FROM view_warehouse_inventory ORDER BY inventory_id DESC";
        public const string getWarehouseReturn = @"SELECT * FROM view_return_warehouse ";
        public const string getServices = "SELECT * FROM view_services ORDER BY service_id DESC";
        public const string getWarehouseDelivery = @"SELECT * FROM view_warehouse_delivery ORDER BY delivery_id DESC";
        public const string getAcceptedDelivery = @"SELECT * FROM view_accepted_delivery WHERE branch_details = @branch ORDER BY received_id DESC";
        public const string getCreditSales = @"SELECT * FROM view_credit_sales WHERE branch = @branch ORDER BY id DESC";
        public const string getContactById = @"SELECT * FROM contact WHERE contact_id = @contact";
        public const string getAddressById = @"SELECT * FROM address WHERE address_id = @address";
    }
}