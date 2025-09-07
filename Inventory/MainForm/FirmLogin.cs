using System;
using System.Windows.Forms;
using Inventory.Config;
using Inventory.PopupForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Helper;
using ServeAll.Core.Utilities;
using Constant = Inventory.Config.Constant;

namespace Inventory.MainForm
{
    public partial class FirmLogin : Form
    {
        private int _loginSuccess;
        public int UserId { get; set; }
        public int UserTy { get; set; }
        public string _userName { get; set; }
        private int limitReg;
        private int regValue;
        public int LoginSuccess
        {
            get { return _loginSuccess; }
            set
            {
                _loginSuccess = value;
                if (_loginSuccess > 0 && UserId > 0 && UserTy > 0)
                {

                    /**
                     * if limitReg >= regValue
                     *  string subKey = @"Software\com\pos\wizard\read";
                        string keyName = "regWizard";
                        string keyValue = "1" + 1;
                     * *
                     */
                    LaunchMain(_userName);
                }
            }
        }
        public FirmLogin()
        {
            InitializeComponent();
        }

        private void FirmLogin_Load(object sender, EventArgs e)
        {
            //readAuthorization();
            PanelInterface.SetMainPanelPosition(this, pnlMain);
        }

        private void Login(int utyp)
        {
            intWET.ShowWaitForm();
            var log = new FirmPopLogin(utyp)
            {
                Login = this
            };
            intWET.CloseWaitForm();
            log.ShowDialog();
        }

        private void LaunchMain(string userName)
        {
            var main = new FirmMain(UserId, UserTy, userName);
            main.Show();
            Hide();
        }

        private void bntAdmin_Click(object sender, EventArgs e)
        {
           
            Login(Constant.LogAmin);
            
        }

        private void bntUser_Click(object sender, EventArgs e)
        {
            Login(Constant.LogUser);
        }

        private void bntLCL_Click(object sender, EventArgs e)
        {
            UserId = 0;                
            UserTy = Constant.LogGues; 
            string guestName = "Guest";
            LaunchMain(guestName);
        }

        private void bntExit_Click(object sender, EventArgs e)
        {
            Constant.ApplicationExit();
        }

        private void bntONL_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMessageQuestion("WARNING: Any alteration of Default Settings may result to unable to access the INVENTORY PROGRAM. Are you sure you want to continue?", Messages.InventorySystem);
            if (!que) return;
            var auth = new FrmPopAuthen()
            {
                Main = this
            };
            auth.ShowDialog();
        }

        private AuthorizedMachine getAuthorizedMachine(string machineKey, string machineName)
        {
            try
            {
                var result = EntityUtils.getMachineDetails(machineKey, machineName);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private void readAuthorization()
        {
            string pcName = Environment.MachineName;
            var regPath = PathHelper.SOFTPATH;
            var regKey = PathHelper.SOFTKEY;
            var readKey = RegistryHelper.ReadFromRegistry(regPath, regKey);
            string decryptedKey = "";

            if (readKey != null && !string.IsNullOrEmpty(readKey.ToString()))
            {
                const string salt = PasswordCipter.EncryptionPass;
                decryptedKey = StringCipher.Decrypt(readKey.ToString().Trim(), salt);
            } else
            {
                decryptedKey = "";
            }

            var authorization = getAuthorizedMachine(decryptedKey, pcName);
            if (authorization == null)
            {
                var registration = new FirmPopServer();
                registration.Show();
                Hide();
            }
        }
    }
}