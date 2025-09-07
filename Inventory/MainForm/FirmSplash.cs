using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Inventory.MainForm
{
    public partial class FirmSplash : SplashScreen
    {
        public FirmSplash()
        {
            InitializeComponent();
            ApplyRoundedCorners(30);
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
        private void ApplyRoundedCorners(int radius)
        {
            var bounds = new Rectangle(0, 0, this.Width, this.Height);
            var path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(bounds.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(bounds.Width - radius, bounds.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, bounds.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }
    }
}