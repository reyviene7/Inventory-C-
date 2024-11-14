using System.Windows.Forms;

namespace Inventory.Config
{
    public static class Constant
    {
        public const float LocXStar = (float)494.67;
        public const float LocYStar = (float)55.33;
        public const float LocDStarX =(float) 84.29;
        public const float LocDStarY = (float) 77.6;
        public const float LocDEndsX = (float)84.29;
        public const float LocDEndsY = (float)98.52;
        public const float LocDBranX = (float) 87.49;
        public const float LocDBranY = (float) 27.54;
        public const float LocXEnds = (float)494.67;
        public const float LocYEnds = (float)76.25;
        public const float PreXStar = (float)82.01;
        public const float PreYStar = (float)122.5;
        public const float BranchXxs = (float)22.5;
        public const float BranchYxs = (float)100.28;

        public const float AppXStar = (float)495.23;
        public const float AppYStar = (float)122.5;
         
        public const int ReportDepotDelivery = 1;
        public const int ReportWareHouseItem = 2;
        public const int ReportWareHouseDelr = 3;
        public const int ReportReturnWarehos = 4;
        public const int ReportReturnDepotDl = 5;
        public const int ReportSummarWareBra = 6;
        public const int SizeWidth = 215;
        public const int SizeHeight = 21;
        public const int FontSize = 10;
        public const string DefaultApprove = "Angela Reyes-Javier";
        public const float DetSizeWidth = (float) 118.84;
        public const float DetSizeheight = (float)20.92;
        public const string DefaultInvoice = "#000";
        public const string DefaultReturnHome = "Depot";
        public const string DefaultWareHouse = @"Warehouse";
        public const string DefaultPayment = @"Credit Card";
        public const string DefaultNone = @"N/A";
        public const string DefaultReturnNone = "None";
        public const string DefaultAmounts = "00.00";
        public const int DefaultZero = 0;
        public const string VernadaFont = "Vernada";
        public const string DateFormat = "MM-dd-yyyy";
        public const string AdminAccount = "Admin Account";
        public const string UserAccount = "User Account";
        public const string GuessAccount = "Guess Account";
        public const string DefaultDepots = "Depot";
        public const string AddFilterLpg = "PRODUCTS";
        public const string AddFilterEmp = "EMPTY";
        public const string Barcode = "Barcode";
        public const string InvoiceId = "InvoiceId";
        public const string BranchId = "BranchId";
        public const string BrId = "BrId";
        public const string CustomerId = "CustomerId";
        public const string Customer = "Customer";
        public const string NetSales = "NetSales";
        public const string Gross = "Gross";
        public const string DefaultWarranty = "NO WARRANTY";
        public const string DefaultDelivery = "Delivery";
        public const string DefaultBranch = "Main Branch";
        public const string DefaultSource = "Warehouse";
        public const string DefaultReturn = "Return";
        public const string DefaultEmptyValue = "";
        public const string DefaultEmptyCylinder = "(EMPTY)";
        public const string DefaultFull = "Full";
        public const double DefaultTax = 0.12;
        public static readonly int LogAmin = 1;
        public static readonly int LogUser = 2;
        public static readonly int LogGues = 3;
        public const string LoginAppTitle = "INVENTORY MANAGEMENT SYSTEM";
        public const string RegKey = @"HKEY_CURRENT_USER\Software\iJRT-Software\Serve-All Marketing\System Key";
        public const string Server = "SERVER";
        public const string PasKey = "PASSKEY";
        public const string UseKey = "USERKEY";
        public const string HddKey = "HDD_ID";
        public const string CpuKey = "CPU_ID";
        public const string DefaultServer = @"PC-NAME\DB";
        public const string TimeFormat = "HH:mm:ss";
        public const string ServerString = @"Server=";
        public const string DatabaseStrn = ";Database=";
        public const string UserNameStrn = "; User Id=";
        public const string PassWordStrn = "; Password=";
        public const string EncryptedPassword = "e1n4qG5aRYJMcfBQC+YekPEH3LC8st38Uv3otyf95qpBgMtYPXVx7UX9lE5Sansh/d5IZHdYbBn731nM6I8/FvpMjPUAdRBrx0rVEWlLuZojdki38HNv7fMegAta660o";
        public const string EncryptedUserName ="jGpKa8VR1RxcG7YncvyXMGCT0DFP7OCGOE8Mq93N218wLBdZGUIjlHUvWKTtVIyok616WApnhh2CZ9gP4TIslXfYw0mNKghYPrCanOfLpB7WKbL8A+at8KToL6M6lt/4";
        public static void ApplicationExit()
        {
            if (MessageBox.Show(@"Would you like to exit Inventory Management System?", LoginAppTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}