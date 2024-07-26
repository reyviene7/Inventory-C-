using System;
using System.Windows.Forms;
using Inventory.Config;
using Microsoft.Win32;
using ServeAll.Core.Helper;

namespace Inventory.PopupForm
{
    public partial class FirmPopServer : Form
    {
        public FirmPopAuthentication Main { get; set; }
        private string Server { get; set; }
        private string EncryptedServer { get; set; }
       
        public FirmPopServer()
        {
            InitializeComponent();
        }
        private void FirmPopServer_Load(object sender, EventArgs e)
        {

        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bntSVA_Click(object sender, EventArgs e)
        {
            regWET.ShowWaitForm();
            var serverName = txtNAM.Text.Trim(' ');
            var dataBaseNm = txtDAT.Text.Trim(' ');
            var userNameDb = txtUSR.Text.Trim(' ');
            var passWordDb = txtPSS.Text.Trim(' ');
            Server = Constant.ServerString + serverName + Constant.DatabaseStrn + dataBaseNm + Constant.UserNameStrn + userNameDb + Constant.PassWordStrn + passWordDb;
            EncryptedServer = StringCipher.Encrypt(Server, PasswordCipter.EncryptionPass);
            Registry.SetValue(Constant.RegKey, Constant.DefaultEmptyValue, Constant.DefaultEmptyValue);
            Registry.SetValue(Constant.RegKey, Constant.Server, EncryptedServer, RegistryValueKind.String);
            regWET.CloseWaitForm();
            PopupNotification.PopUpMessages(1, "Registry Server Key Successfully Updated!", Messages.GasulPos);
            Close();
        }
        private void bntCLR_Click(object sender, EventArgs e)
        {
            regWET.ShowWaitForm();
            txtNAM.Text = Constant.DefaultServer;
            txtDAT.Text = Constant.DefaultEmptyValue;
            txtUSR.Text = Constant.DefaultEmptyValue;
            txtPSS.Text = Constant.DefaultEmptyValue;
            Registry.SetValue(Constant.RegKey, Constant.DefaultEmptyValue, Constant.DefaultEmptyValue);
            regWET.CloseWaitForm();
        }
        private void txtNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
                var len = txtNAM.Text.Length;
                if (len > 0)
                {
                    txtDAT.Focus();
                }
            
        }
        private void txtDAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtDAT.Text.Length;
            if (len > 0)
            {
                txtUSR.Focus();
            }
        }
        private void txtUSR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtUSR.Text.Length;
            if (len > 0)
            {
                txtPSS.Focus();
            }
        }
        private void txtPSS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtPSS.Text.Length;
            if (len > 0)
            {
                bntSVA.Focus();
            }
        }
    }
}
