 

using System.Windows.Forms;

namespace Inventory.Config
{
    public class PopupNotification
    {
        public const string ApplicationTitle = @"INVENTORY MANAGEMENT SYSTEM";

        public static void PopUpMessages(int rn, string msgs, string title)
        {
            switch (rn)
            {
                case 0:
                    MessageBox.Show(msgs, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case 1:
                    MessageBox.Show(msgs, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        public static void PopUpMessageExit()
        {
            if (MessageBox.Show(@"Would you like to exit the Inventory Management System?", ApplicationTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public static int PopUpMassageLogOff()
        {
            return MessageBox.Show(@"Would you like to log-off the Inventory Management System?", ApplicationTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 0;
        }

        public static bool PopUpMessageQuestion(string msgs, string title)
        {
            return MessageBox.Show(msgs, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static bool PopUpMessageOption(string msgs, string title)
        {
            return MessageBox.Show(msgs, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void PopUpMessageOptionExit(string msg, string title)
        {
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { Application.Exit(); }
        }

        public static int PopUpMassageLogOffOption(string msgs, string title)
        {
            return MessageBox.Show(msgs, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 0;
        }
    }
}
