 

using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraReports.UI;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace Inventory.Interface
{
    public interface IReadOnlyReport<out TReport, in TEntity> where TReport: DevExpress.XtraReports.UI.XtraReport
                                                       where TEntity: class 
                                            
    {
        void Initialize(XRLabel prePared, XRLabel appProved, IEnumerable<TEntity> dataSource);
        Font FontStylizing(string styleName, int styleSize);
        XRLabel Label(string input, int locXaxis, int locYaxis, float sizeWidth, float sizeHeight, Font font);
        

    }
}
