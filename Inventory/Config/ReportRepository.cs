using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraReports.UI;
using Inventory.Interface;

namespace Inventory.Config
{
    public class ReportRepository<TXtraReport, TEntity>: 
        IReadOnlyReport<TXtraReport, TEntity> where TXtraReport : XtraReport
                                              where TEntity : class 
    {
        public void Initialize(XRLabel pre, XRLabel app, IEnumerable<TEntity> dataSource)
        {
            var xTraReport = new XtraReport { DataSource = dataSource };
            var bandFooter = xTraReport.Bands[BandKind.ReportFooter] as ReportFooterBand;
            bandFooter?.Controls.Add(pre);
            bandFooter?.Controls.Add(app);
            xTraReport.ShowPreviewDialog();
        }

        public Font FontStylizing(string styleName, int styleSize)
        {
            var font = new Font(styleName, styleSize, FontStyle.Bold);
            return font;
        }

        public XRLabel Label(string input, int locXaxis, int locYaxis, float sizeWidth, float sizeHeight, Font font)
        {
            var lbl = new XRLabel
            {
                Name = input,
                Location = new System.Drawing.Point(locXaxis, locYaxis),
                SizeF = new SizeF(sizeWidth, sizeHeight), 
                Font = font
            };
            return lbl;
        }

      
    }
}
