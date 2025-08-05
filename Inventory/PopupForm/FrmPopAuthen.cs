using Inventory.MainForm;
using Inventory.Config;
using System;
using System.Configuration;
using System.Windows.Forms;
using ServeAll.Core.Helper;

namespace Inventory.PopupForm
{
    public partial class FrmPopAuthen : Form
    {
        public FirmLogin Main { get; set; }
        public FrmPopAuthen()
        {
            InitializeComponent();
        }
        private void FrmPopAuthen_Load(object sender, EventArgs e)
        {
            
        }
        private void SetConfig()
        {
            logWET.ShowWaitForm();
            var password = txtPassword.Text.Trim(' ');
            var serverDns = txtServerName.Text.Trim(' ');
            var serverUser = txtUserName.Text.Trim(' ');
            var portNumber = txtPortNumber.Text.Trim(' ');
            var databaseName = txtDatabase.Text.Trim(' ');
            if (password.Length <= 0 ||
                serverDns.Length <= 0 ||
                serverUser.Length <= 0 ||
                portNumber.Length <= 0 ||
                databaseName.Length <= 0)
            {
                logWET.CloseWaitForm();
                return;
            }
            var connStr = $"Server={serverDns};Database={databaseName};User Id={serverUser};Password={password};Port={portNumber};Protocol=Tcp;";
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var section = (ConnectionStringsSection)config.GetSection("connectionStrings");
            string connName = "ServeAll.Properties.Settings.GConString";

            if (section.ConnectionStrings[connName] != null)
            {
                section.ConnectionStrings[connName].ConnectionString = connStr;
                section.ConnectionStrings[connName].ProviderName = "MySql.Data.MySqlClient";
            }
            else
            {
                section.ConnectionStrings.Add(
                    new ConnectionStringSettings(connName, connStr, "MySql.Data.MySqlClient"));
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");

            logWET.CloseWaitForm();
            PopupNotification.PopUpMessages(1, "Server DNS successfully changed!", "Wizard Server Registration");
            Hide();
        }
        private void bntSVA_Click(object sender, EventArgs e)
        {
            SetConfig();
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtPSS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtPassword.Text.Length;
            if (len <= 0)
            {
                PopupNotification.PopUpMessages(0, "Password must not be empty!", Messages.TheWizards);
                txtUserName.Focus();
            }
            else
            {
                bntSVA.Focus();
            }
        }
        private void bntClear_Click(object sender, EventArgs e)
        {
            logWET.ShowWaitForm();
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtServerName.Text = "";
            txtPortNumber.Text = "";
        }
    }
}
