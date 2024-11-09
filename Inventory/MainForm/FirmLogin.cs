using System;
using System.Windows.Forms;
using Inventory.Config;
using Inventory.PopupForm;
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
            /***
             read from remote database the encrypted limit int
             read if exist if does not exist write from local registry int

             */
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
         Login(Constant.LogGues);
        
        }

        private void bntExit_Click(object sender, EventArgs e)
        {
            Constant.ApplicationExit();
        }

        private void bntONL_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMessageQuestion("WARNING: Any alteration of Default Settings may result to unable to access the INVENTORY PROGRAM. Are you sure you want to continue?", Messages.InventorySystem);
            if (!que) return;
            var auth = new FirmPopAuthentication()
            {
                Main = this
            };
            auth.ShowDialog();
        }


    }
}