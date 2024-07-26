using System.Drawing;
using System.Windows.Forms;

namespace Inventory.Config
{
    public class PanelInterface
    {
        //For animated panels position
        public static int OptionsX;
        public static int OptionsY;
        public static int RightX;
        public static int RightY;
        //For animated panels direction
        public static string OptionsDirection = "down";
        public static string ToastDirection = "down";
        public static string RightDirection = "right";
        //For animated panels timeout
        public static int OptionsTimeOut = 0;
        public static int ToastTimeOut = 0;
        public static int RightTimeOut = 0;

        //Center Screen 
        public static void SetFullScreen(Form frm)
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            frm.Location = new Point(0, 0);
            frm.Size = new Size(x, y);
        }
        //method to set the position of the main panel that holds the controls to center of the form.
        public static void SetMainPanelPosition(Form frm, Panel pnl)
        {
            int mX = (frm.Width - pnl.Width) / 2;
            int mY = (frm.Height - pnl.Height) / 2;
            pnl.Location = new Point(mX, mY);
        }
        //Panel Option Down
        public static void SetOptionsPanelPosition(Form frm, Panel Opnl, PictureBox Hpnl)
        {
            int x = frm.Width;
            OptionsX = 0;
            OptionsY = frm.Height + Opnl.Height;
            Opnl.Size = new Size(x, Opnl.Height);
            Opnl.Location = new Point(OptionsX, OptionsY);
            Hpnl.Location = new Point(frm.Width - 41, Hpnl.Location.Y);
            int mX = (Opnl.Width - Opnl.Width) / 2;
            int mY = Opnl.Location.Y;
            Opnl.Location = new Point(mX, mY);
            // cmbAcademicYear.Location = new Point(Width - 125, cmbAcademicYear.Location.Y);
            // lblAcademicYear.Location = new Point(Width - 226, lblAcademicYear.Location.Y);
        }

        public static void SetRightOptionsPanelPosition(Form frm, Panel pnlROptn, Panel pnlRMain)
        {
            int y = frm.Height;
            RightY = 0;
            RightX = frm.Width + pnlROptn.Width;
            pnlROptn.Size = new Size(pnlROptn.Width, y);
            pnlROptn.Location = new Point(RightX, RightY);
            int rX = pnlRMain.Location.X;
            int rY = (pnlROptn.Height - pnlRMain.Height) / 2;
            pnlRMain.Location = new Point(rX, rY);
        }
        //CLOCK DOWN OPTION TICK
        public static void OptionTick(Form frm, Panel pnlOpn)
        {
            if (OptionsTimeOut < 1000)
            {
                OptionsTimeOut++;
            }
            if (OptionsTimeOut == 1000)
            {
                if (OptionsDirection == "up")
                {
                    OptionsDirection = "down";
                }
            }
            if (OptionsDirection == "up")
            {
                if (OptionsY > frm.Height - pnlOpn.Height + 3)
                {
                    OptionsY -= 3;
                    pnlOpn.Location = new Point(OptionsX, OptionsY);
                }
            }
            else
            {
                if (OptionsY < frm.Height)
                {
                    OptionsY += 3;
                }
                pnlOpn.Location = new Point(OptionsX, OptionsY);
            }
        }
        // CLOCK RIGHT OPTION TICK
        public static void RightOptionTick(Form frm, Panel pnlRighOp)
        {
            if (RightTimeOut < 1000)
            {
                RightTimeOut++;
            }
            if (RightTimeOut == 1000)
            {
                if (RightDirection == "left")
                {
                    RightDirection = "right";
                }
            }
            if (RightDirection == "left")
            {
                if (RightX > frm.Width - pnlRighOp.Width)
                {
                    RightX -= 2;
                    pnlRighOp.Location = new Point(RightX, RightY);
                }
            }
            else
            {
                if (RightX < frm.Width)
                {
                    RightX += 2;
                }
                pnlRighOp.Location = new Point(RightX, RightY);
            }

        }
        //MOUSE MOVE 
        public static void MouseMOve(Form frm, Panel pnlRightOp, MouseEventArgs e)
        {
            if (e.Y >= frm.Height - 15 && e.X < (frm.Width - pnlRightOp.Width))
            {
                OptionsDirection = "up";
                RightDirection = "right";
                OptionsTimeOut = 0;
            }
            if (e.X >= frm.Width - 15)
            {
                RightDirection = "left";
                RightTimeOut = 0;
                OptionsDirection = "down";
            }
            if (e.X < (frm.Width - pnlRightOp.Width))
            {
                RightDirection = "Left";
            }
        }
    }
}
