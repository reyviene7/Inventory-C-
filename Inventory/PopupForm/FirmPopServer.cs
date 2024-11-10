using System;
using System.Windows.Forms;
using Inventory.Config;
using Microsoft.Win32;
using ServeAll.Core.Entities;
using ServeAll.Core.Helper;
using ServeAll.Core.Repository;

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
            string pcName = Environment.MachineName;
            txtComputerName.Text = pcName;
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bntSVA_Click(object sender, EventArgs e)
        {
            regWET.ShowWaitForm();
            var serverName = txtComputerName.Text.Trim(' ');
            var key1 = txtFirstKey.Text.Trim(' ');
            var key2 = txtSecondKey.Text.Trim(' ');
            var key3 = txtThirdKey.Text.Trim(' ');
            Server = key1 + key2 + key3;

            if (Server.Trim(' ') == PathHelper.KEYS)
            {
                EncryptedServer = StringCipher.Encrypt(Server, PasswordCipter.EncryptionPass);
                regWET.CloseWaitForm();
                var regPath = PathHelper.SOFTPATH;
                var regKey = PathHelper.SOFTKEY;
                bool reg = RegistryHelper.WriteToRegistry(regPath, regKey, EncryptedServer);
                if (reg)
                {
                    DateTime currentDate = DateTime.Now.Date;
                    var authorized = new AuthorizedMachine
                    {
                        machine_name = serverName,
                        machine_key = Server,
                        date_register = currentDate
                    };
                    insertAuthKey(authorized);
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Sorry unable to register your PosWizard copy!", Messages.InventorySystem);
                }
            }
            else {
                PopupNotification.PopUpMessages(0, "Incorrect Serial key, please contact administrator!", Messages.InventorySystem);
            }
            Close();
        }
        private void bntCLR_Click(object sender, EventArgs e)
        {
            regWET.ShowWaitForm();
            txtFirstKey.Text = Constant.DefaultEmptyValue;
            txtSecondKey.Text = Constant.DefaultEmptyValue;
            txtThirdKey.Text = Constant.DefaultEmptyValue;
            Registry.SetValue(Constant.RegKey, Constant.DefaultEmptyValue, Constant.DefaultEmptyValue);
            regWET.CloseWaitForm();
        }
        private void txtNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
                var len = txtComputerName.Text.Length;
                if (len > 0)
                {
                    txtFirstKey.Focus();
                }
            
        }
        private void txtDAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtFirstKey.Text.Length;
            if (len > 0)
            {
                txtSecondKey.Focus();
            }
        }
        private void txtUSR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtSecondKey.Text.Length;
            if (len > 0)
            {
                txtThirdKey.Focus();
            }
        }
        private void txtPSS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtThirdKey.Text.Length;
            if (len > 0)
            {
                bntSVA.Focus();
            }
        }

        private void insertAuthKey(AuthorizedMachine machine)
        {
            var result = RepositoryEntity.AddDomain<AuthorizedMachine>(machine);
            if (result > 0L)
            {
                regWET.ShowWaitForm();
                PopupNotification.PopUpMessages(1, "Thank you for registering PosWizard!", Messages.InventorySystem);
            }
            else
            {
                regWET.CloseWaitForm();
                PopupNotification.PopUpMessages(0, "Sorry unable to register your PosWizard copy!", Messages.InventorySystem);
            }
        }
    }
}
