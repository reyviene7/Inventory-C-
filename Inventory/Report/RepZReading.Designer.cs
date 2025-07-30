// RepZReading.Designer.cs
namespace Inventory.Report
{
    partial class RepZReading
    {
        private DevExpress.XtraReports.UI.XRLabel lblTerminal;
        private DevExpress.XtraReports.UI.XRLabel lblCashier;
        private DevExpress.XtraReports.UI.XRLabel lblDate;
        private DevExpress.XtraReports.UI.XRLabel lblTransactions;
        private DevExpress.XtraReports.UI.XRLabel lblGross;
        private DevExpress.XtraReports.UI.XRLabel lblDiscount;
        private DevExpress.XtraReports.UI.XRLabel lblVAT;
        private DevExpress.XtraReports.UI.XRLabel lblNet;
        private DevExpress.XtraReports.UI.XRLabel lblCash;
        private DevExpress.XtraReports.UI.XRLabel lblGCash;
        private DevExpress.XtraReports.UI.XRLabel lblCredit;
        private DevExpress.XtraReports.UI.DetailBand detailBand;

        private void InitializeComponent()
        {
            this.detailBand = new DevExpress.XtraReports.UI.DetailBand();
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
        detailBand
    });

            this.lblTerminal = CreateLabel("Terminal:", 0);
            this.lblCashier = CreateLabel("Cashier:", 1);
            this.lblDate = CreateLabel("Date:", 2);
            this.lblTransactions = CreateLabel("No. of Transactions:", 3);
            this.lblGross = CreateLabel("Gross Sales:", 4);
            this.lblDiscount = CreateLabel("Discount:", 5);
            this.lblVAT = CreateLabel("VAT:", 6);
            this.lblNet = CreateLabel("Net Sales:", 7, true);
            this.lblCash = CreateLabel("Cash:", 8);
            this.lblGCash = CreateLabel("GCash:", 9);
            this.lblCredit = CreateLabel("Credit:", 10);

            this.Version = "23.1";
        }

        private DevExpress.XtraReports.UI.XRLabel CreateLabel(string labelText, int index, bool isBold = false)
        {
            var labelTitle = new DevExpress.XtraReports.UI.XRLabel
            {
                Text = labelText,
                LocationF = new System.Drawing.PointF(0, 25 * index),
                SizeF = new System.Drawing.SizeF(200, 25),
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular),
                TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            };

            var valueLabel = new DevExpress.XtraReports.UI.XRLabel
            {
                LocationF = new System.Drawing.PointF(210, 25 * index),
                SizeF = new System.Drawing.SizeF(300, 25),
                Font = new System.Drawing.Font("Segoe UI", 10F, isBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular),
                TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft,
                Text = "..."
            };

            // ⛔️ this.Controls.Add(...) → ❌
            // ✅ Correctly add to DetailBand:
            detailBand.Controls.Add(labelTitle);
            detailBand.Controls.Add(valueLabel);

            return valueLabel;
        }

    }
}
