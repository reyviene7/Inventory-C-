using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            labelTitle.Text = caption;
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
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int widthEllipse, int heightEllipse);

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}