// RepZReading.cs
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace Inventory.Report
{
    public partial class RepZReading : XtraReport
    {
        public RepZReading()
        {
            InitializeComponent();
        }

        public void LoadData(
            string terminal,
            string cashier,
            string date,
            int noOfTransactions,
            decimal grossSales,
            decimal discount,
            decimal vat,
            decimal netSales,
            decimal cash,
            decimal gcash,
            decimal credit)
        {
            lblTerminal.Text = terminal;
            lblCashier.Text = cashier;
            lblDate.Text = date;
            lblTransactions.Text = noOfTransactions.ToString();
            lblGross.Text = grossSales.ToString("C2");
            lblDiscount.Text = discount.ToString("C2");
            lblVAT.Text = vat.ToString("C2");
            lblNet.Text = netSales.ToString("C2");
            lblCash.Text = cash.ToString("C2");
            lblGCash.Text = gcash.ToString("C2");
            lblCredit.Text = credit.ToString("C2");
        }
    }
}