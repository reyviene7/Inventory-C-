using System.Windows.Forms;
using Inventory.Config;
using Inventory.MainForm;
using Microsoft.Win32;
using ServeAll.Core.Helper;

namespace Inventory.PopupForm
{
    public partial class FirmPopAuthentication : Form
    {
        public FirmLogin Main { get; set; }
        public FirmPopAuthentication()
        {
            InitializeComponent();
        }

        private void txtUSR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtUSR.Text.Length;
                if (len > 0)
                {
                    txtPSS.Focus();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Username must not be empty!", Messages.GasulPos);
                    txtUSR.Focus();
                }
            }
        }
        private void txtPASS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtPSS.Text.Length;
            if (len <= 0)
            {
                PopupNotification.PopUpMessages(0, "Password must not be empty!", Messages.GasulPos);
                txtUSR.Focus();
            }
            else
            {
                bntSVA.Focus();
            }
        }

        private void bntSVA_Click(object sender, System.EventArgs e)
        {
            logWET.ShowWaitForm();
            var enCryptedPass = GetSettings.DefaultPassWord();
            var passWord = StringCipher.Decrypt(enCryptedPass, PasswordCipter.EncryptionPass);
           
            var valPassW = txtPSS.Text.Trim(' ');
            if (valPassW.Length > 0)
            {
                if (string.Equals(passWord, valPassW))
                {
                    logWET.CloseWaitForm();
                    Hide();
                    var serv = new FirmPopServer()
                    {
                        Main = this
                    };
                    serv.ShowDialog();
                }
                else
                {
                    logWET.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Username or Password is incorrect! ", Messages.GasulPos);
                }
                
            }

        }
        private void FirmPopAuthentication_Load(object sender, System.EventArgs e)
        {
            Registry.SetValue(Constant.RegKey, Constant.DefaultEmptyValue, Constant.DefaultEmptyValue);
            Registry.SetValue(Constant.RegKey, Constant.PasKey, Constant.EncryptedPassword, RegistryValueKind.String);
        }
        private void bntCAN_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
