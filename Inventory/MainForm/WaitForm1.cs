using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Inventory.MainForm
{
    public partial class WaitForm1 : WaitForm
    {
        public WaitForm1()
        {
            InitializeComponent(); 
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            labelTitle.Text = caption;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int radius = 25; // Adjust for smoother roundness
            using (GraphicsPath path = GetRoundedPath(new Rectangle(0, 0, this.Width, this.Height), radius))
            {
                this.Region = new Region(path);
            }
            this.Invalidate();
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            float r2 = radius * 2f;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            // Top-left corner
            path.AddArc(rect.X, rect.Y, r2, r2, 180, 90);

            // Top edge
            path.AddLine(rect.X + radius, rect.Y, rect.Right - radius, rect.Y);

            // Top-right corner
            path.AddArc(rect.Right - r2, rect.Y, r2, r2, 270, 90);

            // Right edge
            path.AddLine(rect.Right, rect.Y + radius, rect.Right, rect.Bottom - radius);

            // Bottom-right corner
            path.AddArc(rect.Right - r2, rect.Bottom - r2, r2, r2, 0, 90);

            // Bottom edge
            path.AddLine(rect.Right - radius, rect.Bottom, rect.X + radius, rect.Bottom);

            // Bottom-left corner
            path.AddArc(rect.X, rect.Bottom - r2, r2, r2, 90, 90);

            // Left edge
            path.AddLine(rect.X, rect.Bottom - radius, rect.X, rect.Y + radius);

            path.CloseFigure();
            return path;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            labelControl2.Text = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // smooth edges
        }
        #endregion

        public enum WaitFormCommand
        {
        }
    }
}