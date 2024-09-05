using System;
using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Inventory.Report;
using Inventory.Services;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;

namespace Inventory.Config
{
    public static class ReportSetting
    {
        public static void ListofInventoryProducts(string fullName)
        {
            var report = new RepInventoryItem();
            var serv = new ServInventoryList();
            var dataSource = serv.DataSource();
            report.Load(dataSource);
            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter,
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void ListofProductItem(string fullName)
        {
            var report = new RepItemProduct();
            var serv = new ServProductsItem();
            var dataSource = serv.DataSource();
            report.Load(dataSource);
            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter,
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void DepotDeliver(DateTime startDate, DateTime endngDate, string fullName)
        {
            var report = new RepDepotDelivery();
            var serv = new ServDepotDelivery();
            var dataSource = serv.DataSource(startDate, endngDate);
            report.Load(dataSource);
            var starDate = new XRLabel
            {
                Text = startDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocDStarX, Constant.LocDStarY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var endDate = new XRLabel
            {
                Text = endngDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocDEndsX, Constant.LocDEndsY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };

            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            var bandH = report.Bands[BandKind.ReportHeader] as ReportHeaderBand;
            bandH?.Controls.Add(starDate);
            bandH?.Controls.Add(endDate);
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void WareHouseDelivery(string branch, DateTime startDate, DateTime endngDate, string fullName)
        {
            var report = new RepWareHouseDelivery();
            var serv = new ServWareHouseDelivery();
            var dataSource = serv.DataSource(branch, startDate, endngDate);
            report.Load(dataSource);
            var starBrnd = new XRLabel
            {
                Text = branch,
                LocationF = new PointF(Constant.LocDBranX, Constant.LocDBranY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };

            var starDate = new XRLabel
            {
                Text = startDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocDStarX, Constant.LocDStarY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var endDate = new XRLabel
            {
                Text = endngDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocDEndsX, Constant.LocDEndsY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };

            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            var bandH = report.Bands[BandKind.ReportHeader] as ReportHeaderBand;
            bandH?.Controls.Add(starBrnd);
            bandH?.Controls.Add(starDate);
            bandH?.Controls.Add(endDate);
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void ReturnWareHouseDelivery(string branch, DateTime startDate, DateTime endngDate, string fullName)
        {
            var report = new RepReturnWareHouse();
            var serv = new ServReturnWareHouse();
            var dataSource = serv.DataSource(branch, startDate, endngDate);
            report.Load(dataSource);
            var starBrnd = new XRLabel
            {
                Text = branch,
                LocationF = new PointF(Constant.LocDBranX, Constant.LocDBranY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };

            var starDate = new XRLabel
            {
                Text = startDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocDStarX, Constant.LocDStarY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var endDate = new XRLabel
            {
                Text = endngDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocDEndsX, Constant.LocDEndsY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };

            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            var bandH = report.Bands[BandKind.ReportHeader] as ReportHeaderBand;
            bandH?.Controls.Add(starBrnd);
            bandH?.Controls.Add(starDate);
            bandH?.Controls.Add(endDate);
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void WareHouseItem(DateTime startDate, DateTime endngDate, string fullName)
        {
            var report = new RepItemWareHouse();
            var serv = new ServWarehouseItem();
            var dataSource = serv.DataSource(startDate, endngDate);
            report.Load(dataSource);
            var starDate = new XRLabel
            {
                Text = startDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocDStarX, Constant.LocDStarY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var endDate = new XRLabel
            {
                Text = endngDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocDEndsX, Constant.LocDEndsY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };

            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter,
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            var bandH = report.Bands[BandKind.ReportHeader] as ReportHeaderBand;
            bandH?.Controls.Add(starDate);
            bandH?.Controls.Add(endDate);
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void ReturnDepot(DateTime startDate, DateTime endngDate, string fullName)
        {
            var report = new RepReturnDepot();
            var serv = new ServReturnDepot();
            var dataSource = serv.DataSource(startDate, endngDate);
            report.Load(dataSource);
            var starDate = new XRLabel
            {
                Text = startDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocXStar, Constant.LocYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var endDate = new XRLabel
            {
                Text = endngDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocXEnds, Constant.LocYEnds),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };

            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            var bandH = report.Bands[BandKind.ReportHeader] as ReportHeaderBand;
            bandH?.Controls.Add(starDate);
            bandH?.Controls.Add(endDate);
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void ListofSalesItem(string fullName)
        {
            var report = new RepSalesItem();
            var serv = new ServReportSales();
            var dataSource = serv.DataSource();
            report.Load(dataSource);
            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter,
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void ListofSalesParticular(string fullName)
        {
            var report = new RepSalesParticular();
            var serv = new ServSalesParticular();
            var dataSource = serv.DataSource();
            report.Load(dataSource);
            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter,
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void ListofCreditItem(string fullName)
        {
            var report = new RepCreditItem();
            var serv = new ServReportCredit();
            var dataSource = serv.DataSource();
            report.Load(dataSource);
            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter,
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void ListofCreditParticular(string fullName)
        {
            var report = new RepCreditParticular();
            var serv = new ServCreditParticular();
            var dataSource = serv.DataSource();
            report.Load(dataSource);
            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter,
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        public static void ListofServiceItem(string fullName)
        {
            var report = new RepServiceItem();
            var serv = new ServReportService();
            var dataSource = serv.DataSource();
            report.Load(dataSource);
            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter,
            };
            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
        private static int GetCustomerId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Customers>(unWork);
                    var query = repository.FindBy(x => x.customer_name == input);
                    return query.customer_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Customer Type Id Error", "Customer Details");
                    throw;
                }
            }
        }
        public static void DailySummaryWareHouseDelivery(DateTime startDate, DateTime endngDate, string fullName, string branchName)
        {
            var report = new RepSummaryBranchDelivery();
            var serv = new ServSumBranchDelivery();
            var branchId = FetchUtils.getBranchId(branchName);
            var dataSource = serv.GetSummary(startDate, endngDate, branchId);
            report.Load(dataSource);
            var starDate = new XRLabel
            {
                Text = startDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocDStarX, Constant.LocDStarY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var endDate = new XRLabel
            {
                Text = endngDate.Date.ToString(Constant.DateFormat),
                LocationF = new PointF(Constant.LocDEndsX, Constant.LocDEndsY),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Regular),
                SizeF = new SizeF(Constant.DetSizeWidth, Constant.DetSizeheight),
                TextAlignment = TextAlignment.MiddleCenter
            };

            var prePared = new XRLabel
            {
                Text = fullName,
                LocationF = new PointF(Constant.PreXStar, Constant.PreYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };
            var appPared = new XRLabel
            {
                Text = Constant.DefaultApprove,
                LocationF = new PointF(Constant.AppXStar, Constant.AppYStar),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };

            var appBrnch = new XRLabel
            {
                Text = branchName,
                LocationF = new PointF(Constant.BranchXxs, Constant.BranchYxs),
                Font = new Font(Constant.VernadaFont, Constant.FontSize, FontStyle.Underline),
                Size = new Size(Constant.SizeWidth, Constant.SizeHeight),
                TextAlignment = TextAlignment.MiddleCenter
            };

            var band = report.Bands[BandKind.ReportFooter] as ReportFooterBand;
            var bandH = report.Bands[BandKind.ReportHeader] as ReportHeaderBand;
            bandH?.Controls.Add(appBrnch);
            bandH?.Controls.Add(starDate);
            bandH?.Controls.Add(endDate);
            band?.Controls.Add(prePared);
            band?.Controls.Add(appPared);
            report.ShowPreviewDialog();
        }
    }
}
